using Kosy.Factories;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Repositories
{
    public class CartRepository
    {
        KosyDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserID == userId).ToList();
        }

        public int getLastID()
        {
            return (from x in db.Carts select x.CartID).ToList().LastOrDefault();
        }

        public int generateId()
        {
            if (db.Carts.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }

        public void AddToCart(int userId, int propertyId, int quantity)
        {
            try
            {
                Cart cartItem = (from x in db.Carts where x.UserID == userId && x.PropertyID == propertyId select x).FirstOrDefault();

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cartItem = CartFactory.Create(generateId(), userId, propertyId, quantity);
                    db.Carts.Add(cartItem);
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding to cart", ex);
            }
        }

        public void ClearCart(int userId)
        {
            List<Cart> cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        public void RemoveCartsByPropertyId(int propertyId)
        {
            List<Cart> cartItems = (from cart in db.Carts where cart.PropertyID == propertyId select cart).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }
    }
}
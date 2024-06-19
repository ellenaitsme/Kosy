using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class CartHandler
    {
        CartRepository cartRepo = new CartRepository();

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return cartRepo.GetCartItemsByUserId(userId);
        }

        public void AddToCart(int userId, int propertyId, int quantity)
        {
            cartRepo.AddToCart(userId, propertyId, quantity);
        }

        public void ClearCart(int userId)
        {
            cartRepo.ClearCart(userId);
        }
    }
}
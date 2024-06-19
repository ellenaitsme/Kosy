using Kosy.Handler;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Controller
{
    public class CartController
    {
        CartHandler cartHandler = new CartHandler();
        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return cartHandler.GetCartItemsByUserId(userId);
        }

        public void AddToCart(int userId, int propertyId, int quantity)
        {
            cartHandler.AddToCart(userId, propertyId, quantity);
        }

        public void ClearCart(int userId)
        {
            cartHandler.ClearCart(userId);
        }
    }
}
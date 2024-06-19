using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Factories
{
    public class CartFactory
    {
        public static Cart Create(int id, int userId, int propertyId, int quantity)
        {
            Cart cart = new Cart();
            cart.CartID = id;
            cart.UserID = userId;
            cart.PropertyID = propertyId;
            cart.Quantity = quantity;
            return cart;
        }
    }
}
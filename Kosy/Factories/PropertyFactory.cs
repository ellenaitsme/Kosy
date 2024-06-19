using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Factories
{
    public class PropertyFactory
    {
        public static Property Create(int id, String name, int price, int area, int typeId, int ownerId)
        {
            Property property = new Property();
            property.PropertyID = id;
            property.PropertyName = name;
            property.PropertyPrice = price;
            property.PropertyArea = area;
            property.PropertyTypeID = typeId;
            property.OwnerID = ownerId;
            return property;
        }
    }
}
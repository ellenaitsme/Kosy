using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Factories
{
    public class PropertyOwnerFactory
    {
        public static PropertyOwner Create(int id, String name, int rating)
        {
            PropertyOwner propertyOwner = new PropertyOwner();
            propertyOwner.OwnerID = id;
            propertyOwner.OwnerName = name;
            propertyOwner.OwnerRating = rating;
            return propertyOwner;
        }
    }
}
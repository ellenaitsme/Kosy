using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Factories
{
    public class PropertyTypeFactory
    {
        public static PropertyType Create(int id, String name)
        {
            PropertyType propertyType = new PropertyType();
            propertyType.PropertyTypeID = id;
            propertyType.PropertyTypeName = name;
            return propertyType;
        }
    }
}
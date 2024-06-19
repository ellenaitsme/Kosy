using Kosy.Handler;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Controller
{
    public class PropertyController
    {
        PropertyHandler propertyHandler = new PropertyHandler();
        PropertyOwnerHandler ownerHandler = new PropertyOwnerHandler();
        PropertyTypeHandler typeHandler = new PropertyTypeHandler();

        public bool validateName(String name)
        {
            if (name.Length >= 1 && name.Length <= 99)
            {
                return true;
            }
            else return false;
        }
        public bool validateRate(int rating)
        {
            if (rating >= 0 && rating <= 100)
            {
                return true;
            }
            return false;
        }

        public bool validate(String name, String price, String area, String typeId, String ownerID)
        {
            if (name != null && price != null && area != null && typeId != null && ownerID != null)
            {
                int p = Convert.ToInt32(price);
                int a = Convert.ToInt32(area);

                if (validateName(name) && p >= 1 && a <= 1500)
                {
                    return true;
                }
                else return false;
            }

            else return false;
        }

        public List<Property> getAllProperties()
        {
            return propertyHandler.getAllProperties();
        }

        //tammpilin semua makeup brand dengan rating sort secara descending
        public List<PropertyOwner> GetAllOwnersDesc()
        {
            return ownerHandler.getPropertyOwnersDesc();
        }

        public List<PropertyType> GetAllTypes()
        {
            return typeHandler.GetPropertyTypes();
        }


        public void removeProperty(int id)
        {
            propertyHandler.removeProperty(id);
        }

        public void removePropertyType(int id)
        {
            typeHandler.DeletePropertyType(id);
        }

        public void removePropertyOwner(int id)
        {
            ownerHandler.DeletePropertyOwner(id);
        }

        public void addProperty(String name, int price, int weight, int typeID, int ownerID)
        {
            propertyHandler.addProperty(name, price, weight, typeID, ownerID);
        }

        public Property getPropertyByID(int id)
        {
            return propertyHandler.getPropertyByID(id);
        }

        public void updateProperty(int id, String name, int price, int area, int typeID, int owenrID)
        {
            propertyHandler.updateProperty(id, name, price, area, typeID, owenrID);
        }

        //property type
        public void addPropertyType(String name)
        {
            typeHandler.addPropertyType(name);
        }
        public PropertyType GetPropertyTypeByID(int id)
        {
            return typeHandler.getPropertyTypeById(id);
        }
        public void updatePropertyType(int id, String name)
        {
            typeHandler.updatePropertyType(id, name);
        }

        //property owner
        public void addPropertyOwner(String name, int rating)
        {
            ownerHandler.addPropertyOwner(name, rating);
        }

        public PropertyOwner getPropertyOwnerById(int id)
        {
            return ownerHandler.getPropertyOwnerByID(id);
        }

        public void updatePropertyOwner(int id, String name, int rating)
        {
            ownerHandler.updatePropertyOwner(id, name, rating);
        }
    }
}
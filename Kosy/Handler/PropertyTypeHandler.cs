using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class PropertyTypeHandler
    {
        PropertyTypeRepository typeRepo = new PropertyTypeRepository();

        public void DeletePropertyType(int id)
        {
            PropertyType type = typeRepo.getPropertyTypebyID(id);

            //kalo misalnya PropertyType yang dicari ga ada
            if (type == null)
            {
                //Debug.WriteLine("masuk di type null");
                return;
            }

            if (type.Properties.Count > 0)
            {
                PropertyHandler propertyHandler = new PropertyHandler();
                PropertyRepository propRepo = new PropertyRepository();

                List<Property> properties = propRepo.getPropertiesbyType(id);
                foreach (Property property in properties)
                {
                    propertyHandler.removeProperty(property.PropertyID);
                }
            }

            typeRepo.removePropertyTypes(id);
        }


        public List<PropertyType> GetPropertyTypes()
        {
            return typeRepo.getAllPropertyTypes();
        }

        public void addPropertyType(String name)
        {
            typeRepo.addPropertyType(name);
        }

        public PropertyType getPropertyTypeById(int id)
        {
            return typeRepo.getPropertyTypebyID(id);
        }

        public void updatePropertyType(int id, String name)
        {
            typeRepo.updatePropertyType(id, name);
        }
    }
}
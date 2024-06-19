using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class PropertyOwnerHandler
    {
        PropertyOwnerRepository ownerRepo = new PropertyOwnerRepository();

        public void DeletePropertyOwner(int id)
        {
            PropertyOwner owner = ownerRepo.getPropertyOwnerbyId(id);

            //kalo owner nya ga ketemu
            if (owner == null)
            {
                return;
            }

            if (owner.Properties.Count > 0)
            {
                PropertyHandler propertyHandler = new PropertyHandler();
                PropertyRepository propertyRepo = new PropertyRepository();

                List<Property> properties = propertyRepo.getPropertiesbyOwner(id);
                foreach (Property property in properties)
                {
                    propertyHandler.removeProperty(property.PropertyID);
                }
            }

            ownerRepo.removePropertyOwners(id);
        }

        //ngambil semua make up owner tapi di sort descending dari rating
        public List<PropertyOwner> getPropertyOwnersDesc()
        {
            return ownerRepo.propertyOwnersDesc();
        }

        public void addPropertyOwner(String name, int rating)
        {
            ownerRepo.addPropertyOwner(name, rating);
        }

        public PropertyOwner getPropertyOwnerByID(int id)
        {
            return ownerRepo.getPropertyOwnerbyId(id);
        }

        public void updatePropertyOwner(int id, String name, int rating)
        {
            ownerRepo.updatePropertyOwner(id, name, rating);
        }
    }
}
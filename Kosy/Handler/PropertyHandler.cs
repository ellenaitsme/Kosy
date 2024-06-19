using Kosy.Factories;
using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class PropertyHandler
    {
        PropertyRepository propRepo = new PropertyRepository();
        TransactionRepository tranRepo = new TransactionRepository();
        CartRepository cartRepo = new CartRepository();
        public List<Property> getAllProperties()
        {
            return propRepo.getAllProperties();
        }

        public void removeProperty(int id)
        {
            tranRepo.RemoveTransactionDetailsByPropertyId(id);
            cartRepo.RemoveCartsByPropertyId(id);
            propRepo.removeProperty(id);
        }

        public void addProperty(String name, int price, int weight, int typeID, int ownerID)
        {
            propRepo.addProperty(name, price, weight, typeID, ownerID);
        }

        public Property getPropertyByID(int id)
        {
            return propRepo.getPropertyByID(id);
        }

        public void updateProperty(int id, String name, int price, int area, int typeID, int owenrID)
        {
            propRepo.updateProperty(id, name, price, area, typeID, owenrID);
        }
    }
}
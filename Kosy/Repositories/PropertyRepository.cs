using Kosy.Factories;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Repositories
{
    public class PropertyRepository
    {
        KosyDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<Property> getAllProperties()
        {
            return db.Properties.ToList();
        }

        public void removeProperty(int id)
        {
            Property mu = db.Properties.Find(id);
            db.Properties.Remove(mu);
            db.SaveChanges();
        }

        public List<Property> getPropertiesbyOwner(int id)
        {
            return (from x in db.Properties where x.OwnerID == id select x).ToList();
        }

        public List<Property> getPropertiesbyType(int id)
        {
            return (from x in db.Properties where x.PropertyTypeID == id select x).ToList();
        }

        public void removePropertiesbyOwner(int id)
        {
            List<Property> property = getPropertiesbyOwner(id);
            db.Properties.RemoveRange(property);
            db.SaveChanges();
        }

        public void removePropertiesbyType(int id)
        {
            List<Property> property = getPropertiesbyType(id);
            db.Properties.RemoveRange(property);
            db.SaveChanges();
        }

        public int getLastID()
        {
            return (from x in db.Properties select x.PropertyID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.Properties.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastId = getLastID();
                return ++lastId;
            }
        }

        public void addProperty(String name, int price, int weight, int typeID, int ownerID)
        {
            int id = generateID();
            Property property = PropertyFactory.Create(id, name, price, weight, typeID, ownerID);
            db.Properties.Add(property);
            db.SaveChanges();
        }

        public Property getPropertyByID(int id)
        {
            return (from x in db.Properties where x.PropertyID == id select x).ToList().FirstOrDefault();
        }

        public void updateProperty(int id, String name, int price, int area, int typeID, int owenrID)
        {
            Property property = getPropertyByID(id);
            property.PropertyName = name;
            property.PropertyPrice = price;
            property.PropertyArea = area;
            property.PropertyTypeID = typeID;
            property.OwnerID = owenrID;
            db.SaveChanges();
        }

        public void updatePropertyPrice(int id, int price)
        {
            Property property = getPropertyByID(id);
            property.PropertyPrice = price;
            db.SaveChanges();
        }

    }
}
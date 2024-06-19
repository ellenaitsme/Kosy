using Kosy.Factories;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Kosy.Repositories
{
    public class PropertyOwnerRepository
    {
        KosyDatabaseEntities db = DatabaseSingleton.GetInstance();
        public void removePropertyOwners(int id)
        {
            PropertyOwner brand = db.PropertyOwners.Find(id);
            db.PropertyOwners.Remove(brand);
            db.SaveChanges();
        }

        public PropertyOwner getPropertyOwnerbyId(int id)
        {
            return (from x in db.PropertyOwners where x.OwnerID == id select x).FirstOrDefault();
        }

        public List<PropertyOwner> GetPropertyOwners()
        {
            return db.PropertyOwners.ToList();
        }

        public List<PropertyOwner> propertyOwnersDesc()
        {
            return db.PropertyOwners.OrderByDescending(rating => rating.OwnerRating).ToList();
        }

        public int getLastID()
        {
            return (from x in db.PropertyOwners select x.OwnerID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.PropertyOwners.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }
        public void addPropertyOwner(String name, int rating)
        {
            int id = generateID();
            PropertyOwner propertyOwner = PropertyOwnerFactory.Create(id, name, rating);
            db.PropertyOwners.Add(propertyOwner);
            db.SaveChanges();
        }

        public void updatePropertyOwner(int id, String name, int rating)
        {
            PropertyOwner makeupbr = getPropertyOwnerbyId(id);
            makeupbr.OwnerName = name;
            makeupbr.OwnerRating = rating;
            db.SaveChanges();
        }
    }
}
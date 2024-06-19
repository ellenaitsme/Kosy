using Kosy.Factories;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Repositories
{
    public class PropertyTypeRepository
    {
        KosyDatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<PropertyType> getAllPropertyTypes()
        {
            return db.PropertyTypes.ToList();
        }

        public PropertyType getPropertyTypebyID(int id)
        {
            return (from x in db.PropertyTypes where x.PropertyTypeID == id select x).FirstOrDefault();
        }

        public void removePropertyTypes(int id)
        {
            PropertyType type = db.PropertyTypes.Find(id);
            db.PropertyTypes.Remove(type);
            db.SaveChanges();
        }

        public int getLastId()
        {
            return (from x in db.PropertyTypes select x.PropertyTypeID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.PropertyTypes.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastId = getLastId();
                return ++lastId;
            }
        }
        public void addPropertyType(String name)
        {
            int id = generateID();
            PropertyType type = PropertyTypeFactory.Create(id, name);
            db.PropertyTypes.Add(type);
            db.SaveChanges();
        }

        public void updatePropertyType(int id, String name)
        {
            PropertyType type= getPropertyTypebyID(id);
            type.PropertyTypeName = name;
            db.SaveChanges();
        }
    }
}
using Kosy.Factories;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Repositories
{
    public class TransactionRepository
    {
        KosyDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<TransactionHeader> GetAllTransaction()
        {
            return (from t in db.TransactionHeaders where t.Status == "Accepted" select t).ToList();
        }

        public List<TransactionHeader> GetUserTransaction(User user)
        {
            return (from t in db.TransactionHeaders where user.UserID == t.UserID && t.Status == "Accepted" select t).ToList();
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return (from t in db.TransactionHeaders where t.TransactionID == id select t).FirstOrDefault();
        }

        public List<TransactionHeader> GetAllPendingTransaction()
        {
            return (from t in db.TransactionHeaders where t.Status == "Pending" select t).ToList();
        }

        public void UpdateTransactionStatusById(int id,string status)
        {
            TransactionHeader tranHeader = db.TransactionHeaders.Find(id);
            tranHeader.Status = status;
            db.SaveChanges();
        }

        public int getLastID()
        {
            return (from x in db.TransactionHeaders select x.TransactionID).ToList().LastOrDefault();
        }

        public int generateID()
        {

            if (db.TransactionHeaders.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {
            PropertyRepository proRepo = new PropertyRepository();

            TransactionHeader transactionHeader = TransactionHeaderFactory.Create(generateID(), userId, DateTime.Now, "Pending");
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();

            foreach (var c in cartItems)
            {
                TransactionDetail transactionDetail = TransactionDetailFactory.Create(transactionHeader.TransactionID, c.PropertyID, 1);
                proRepo.updatePropertyPrice(c.PropertyID, c.Quantity);
                db.TransactionDetails.Add(transactionDetail);
                db.SaveChanges();


            }
        }

        public void RemoveTransactionDetailsByPropertyId(int propertyID)
        {
            List<TransactionDetail> tranDetail = (from tran in db.TransactionDetails where tran.PropertyID == propertyID select tran).ToList();
            db.TransactionDetails.RemoveRange(tranDetail);
            db.SaveChanges();
        }
    }
}
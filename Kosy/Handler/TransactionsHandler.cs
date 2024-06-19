using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class TransactionsHandler
    {
        TransactionRepository tranRepo = new TransactionRepository();
        public List<TransactionHeader> GetAllTransaction()
        {
            return tranRepo.GetAllTransaction();
        }
        public List<TransactionHeader> GetUserTransaction(User currUser)
        {
            return tranRepo.GetUserTransaction(currUser);
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return tranRepo.GetTransactionById(id);
        }

        public List<TransactionHeader> GetAllPendingTransaction()
        {
            return tranRepo.GetAllPendingTransaction();
        }

        public void UpdateTransactionStatusById(int id,string status)
        {
            tranRepo.UpdateTransactionStatusById(id, status);
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {
            tranRepo.Checkout(userId, cartItems);
        }
    }
}
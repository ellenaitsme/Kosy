﻿using Kosy.Handler;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Kosy.Controller
{
    public class TransactionController
    {
        TransactionsHandler tranHandler = new TransactionsHandler();
        public List<TransactionHeader> GetAllTransaction()
        {
            return tranHandler.GetAllTransaction();
        }

        public List<TransactionHeader> GetUserTransaction(User currUser)
        {
            return tranHandler.GetUserTransaction(currUser);
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return tranHandler.GetTransactionById(id);
        }

        public List<TransactionHeader> GetAllPendingTransaction()
        {
            return tranHandler.GetAllPendingTransaction();
        }

        public void UpdateTransactionStatusById(int id, string status)
        {
            tranHandler.UpdateTransactionStatusById(id, status);
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {
            tranHandler.Checkout(userId, cartItems);
        }
    }
}
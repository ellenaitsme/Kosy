using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionId, int propertyId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionId;
            transactionDetail.PropertyID = propertyId;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}
using Kosy.Controller;
using Kosy.Dataset;
using Kosy.Models;
using Kosy.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kosy.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else if (((User)Session["user"]).UserRole != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

            TransactionController tranController = new TransactionController();
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            List<TransactionHeader> transactions = tranController.GetAllTransaction();

            DataSet1 data = GetData(transactions);
            report.SetDataSource(data);
        }

        private DataSet1 GetData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            //sesuai dengan nama tabel
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (var t in transactions)
            {
                int subTotal = 0;
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["User"] = t.User.Username;
                hrow["TransactionDate"] = t.TransactionDate;
                


                foreach (var d in t.TransactionDetails)
                {
                    hrow["Owner"] = d.Property.PropertyOwner.OwnerName;
                    //Diisi sesuai dengan database d. nya
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["Property"] = d.Property.PropertyName;
                    drow["Quantity"] = d.Quantity;
                    //sesuai dengan kuantitas barang yang dibeli
                    int totalPrice = d.Property.PropertyPrice * d.Quantity;
                    drow["Price"] = totalPrice;

                    subTotal += totalPrice;
                    detailTable.Rows.Add(drow);
                }

                hrow["SubTotal"] = subTotal;
                headerTable.Rows.Add(hrow);
            }

            return data;
        }
    }
}
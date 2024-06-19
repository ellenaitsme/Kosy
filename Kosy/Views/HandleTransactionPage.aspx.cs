using Kosy.Controller;
using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kosy.Views
{
    public partial class HandleTransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                List<TransactionHeader> unhandledTran = tranController.GetAllPendingTransaction();
                TransactionGV.DataSource = unhandledTran;
                TransactionGV.DataBind();
            }
        }

        protected void TransactionGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Ensure the command is from a ButtonField
            if (e.CommandName == "Accept" || e.CommandName == "Reject")
            {
                // Retrieve the row index stored in the CommandArgument property
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = TransactionGV.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells[0].Text);

                TransactionController tranController = new TransactionController();

                if (e.CommandName == "Accept")
                {
                    // Update the status to Accepted
                    tranController.UpdateTransactionStatusById(id, "Accepted");
                }
                else if (e.CommandName == "Reject")
                {
                    // Update the status to Rejected
                    tranController.UpdateTransactionStatusById(id, "Rejected");
                }

                // Refresh the GridView with updated data
                List<TransactionHeader> unhandledTran = tranController.GetAllPendingTransaction();
                TransactionGV.DataSource = unhandledTran;
                TransactionGV.DataBind();
            }
            else if(e.CommandName == "Detail")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = TransactionGV.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells[0].Text);
                Response.Redirect("~/Views/TransactionDetailPage.aspx?id=" + id);
                
            }
        }


    }
}
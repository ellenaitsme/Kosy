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
    public partial class OrderPropertyPage : System.Web.UI.Page
    {
        PropertyController makeupController = new PropertyController();
        CartController cartController = new CartController();
        TransactionController transactionController = new TransactionController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else if (((User)Session["user"]).UserRole != "User")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                ShowPropertyData();
                ShowCart();
                UpdateCart();
            }
        }

        private void ShowPropertyData()
        {
            List<Property> makeupList = makeupController.getAllProperties();
            PropertyGridView.DataSource = makeupList;
            PropertyGridView.DataBind();
        }

        private void ShowCart()
        {
            User user = (User)Session["user"];
            List<Cart> cartItems = cartController.GetCartItemsByUserId(user.UserID);
            CartList.DataSource = cartItems;
            CartList.DataBind();
        }

        private void UpdateCart()
        {
            User user = (User)Session["user"];
            List<Cart> cartItems = cartController.GetCartItemsByUserId(user.UserID);
            if (cartItems.Any())
            {
                CheckoutBtn.Visible = true;
                ClearCartBtn.Visible = true;
            }
            else
            {
                CheckoutBtn.Visible = false;
                ClearCartBtn.Visible = false;
            }

        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            List<Cart> cartItems = cartController.GetCartItemsByUserId(user.UserID);
            transactionController.Checkout(user.UserID, cartItems);
            cartController.ClearCart(user.UserID);

            ShowCart();
            UpdateCart();
            ShowMessage("Checkout completed successfully.");
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            cartController.ClearCart(user.UserID);
            ShowCart();
            UpdateCart();
            ShowMessage("Cart cleared successfully.");
        }

        private void ShowMessage(string message)
        {
            ErrorLbl.Text = message;
        }

        protected void PropertyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add_to_cart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = PropertyGridView.Rows[rowIndex];
                TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                int makeupId = Convert.ToInt32(PropertyGridView.DataKeys[rowIndex].Value);
                int quantity;

                if (int.TryParse(quantityTextBox.Text, out quantity) && quantity > 0)
                {
                    User user = (User)Session["user"];
                    cartController.AddToCart(user.UserID, makeupId, quantity);
                    ShowMessage("Item added to cart successfully");
                    ShowCart();
                    UpdateCart();
                }
                else
                {
                    ShowMessage("Quantity must be greater than 0.");
                }
            }
        }
    }
}
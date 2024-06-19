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
    public partial class InsertPropertyPage : System.Web.UI.Page
    {
        PropertyController propertyController = new PropertyController();
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
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManagePropertyPage.aspx");
        }

        protected void Insert_Click(object sender, EventArgs e)
        {

            String name = NameTB.Text;
            String price = PriceTB.Text;
            String area = AreaTB.Text;
            String typeId = TypeIDTB.Text;
            String ownerId = OwnerIDTB.Text;



            if (propertyController.validate(name, price, area, typeId, ownerId))
            {
                int p = Convert.ToInt32(price);
                int w = Convert.ToInt32(area);
                int typeID = Convert.ToInt32(TypeIDTB.Text);
                int ownerID = Convert.ToInt32(OwnerIDTB.Text);

                propertyController.addProperty(name, p, w, typeID, ownerID);

                Label.Text = "Data Inserted Successfully";
                Label.Visible = true;
                NameTB.Text = String.Empty;
                PriceTB.Text = String.Empty;
                AreaTB.Text = String.Empty;
                TypeIDTB.Text = String.Empty;
                OwnerIDTB.Text = String.Empty;
            }
            else
            {
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }
    }
}
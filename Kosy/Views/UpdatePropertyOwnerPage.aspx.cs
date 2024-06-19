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
    public partial class UpdatePropertyOwnerPage : System.Web.UI.Page
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

                int id = Convert.ToInt32(Request.QueryString["id"]);
                PropertyOwner propertybr = propertyController.getPropertyOwnerById(id);

                nameinput.Text = propertybr.OwnerName;
                ratinginput.Text = propertybr.OwnerRating.ToString();
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManagePropertyPage.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            String name = nameinput.Text;
            int rating = Convert.ToInt32(ratinginput.Text);

            PropertyOwner propertybr = propertyController.getPropertyOwnerById(id);

            if (propertyController.validateName(name) && propertyController.validateRate(rating))
            {
                propertyController.updatePropertyOwner(id, name, rating);

                Label.Text = "Data Updated Successfully";
                Label.Visible = true;

                nameinput.Text = propertybr.OwnerName;
                ratinginput.Text = propertybr.OwnerRating.ToString();

            }
            else
            {
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }
    }
}
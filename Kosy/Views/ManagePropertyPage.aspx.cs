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
    public partial class ManagePropertyPage : System.Web.UI.Page
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

                refreshPropertyGV();
                refreshPropertyTypeGV();
                refreshPropertyOwnerGV();
            }
        }

        public void refreshPropertyGV()
        {
            List<Property> mu = propertyController.getAllProperties();
            Property.DataSource = mu;
            Property.DataBind();
        }

        public void refreshPropertyTypeGV()
        {
            List<PropertyType> propertyTypes = propertyController.GetAllTypes();
            PropertyTypes.DataSource = propertyTypes;
            PropertyTypes.DataBind();
        }

        public void refreshPropertyOwnerGV()
        {
            List<PropertyOwner> propertyOwners = propertyController.GetAllOwnersDesc();
            PropertyOwners.DataSource = propertyOwners;
            PropertyOwners.DataBind();
        }

        protected void InsertProperty_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertPropertyPage.aspx");
        }

        protected void InsertPropertyType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertPropertyTypePage.aspx");
        }

        protected void InsertPropertyOwner_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertPropertyOwnerPage.aspx");
        }

        protected void Property_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = Property.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdatePropertyPage.aspx?id=" + id);
        }

        protected void Property_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Property.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            propertyController.removeProperty(id);

            refreshPropertyGV();
        }

        protected void PropertyTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = PropertyTypes.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            propertyController.removePropertyType(id);

            refreshPropertyTypeGV();
            refreshPropertyGV();
        }

        protected void PropertyTypes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = PropertyTypes.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdatePropertyTypePage.aspx?id=" + id);
        }

        protected void PropertyOwners_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = PropertyOwners.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdatePropertyOwnerPage.aspx?id=" + id);
        }

        protected void PropertyOwners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = PropertyOwners.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            propertyController.removePropertyOwner(id);

            refreshPropertyOwnerGV();
            refreshPropertyGV();
        }
    }
}
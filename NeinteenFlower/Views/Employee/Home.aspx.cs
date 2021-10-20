using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Employee
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Member"] != null || Session["Administrator"] != null)
            {
                Session.Clear();
            }
            if (Session["Employee"] == null)
            {
                Response.Redirect("~/Views/Employee/Login.aspx");
            }
            UsernameLabel.Text = EmployeeController.Find(Int32.Parse(Session["Employee"].ToString())).EmployeeName;
        }
        protected void FlowerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Employee/ManageFlower.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("Employee") != null)
            {
                Response.Cookies.Set(EmployeeController.Clear());
            }
            Session.Abandon();
            Response.Redirect("~/Views/Employee/Login.aspx");
        }

    }
}
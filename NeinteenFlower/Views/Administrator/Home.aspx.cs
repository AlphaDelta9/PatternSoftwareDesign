using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Member"] != null || Session["Employee"] != null)
            {
                Session.Clear();
            }
            if (Session["Administrator"] == null)
            {
                Response.Redirect("~/Views/Administrator/Login.aspx");
            }
            UsernameLabel.Text = AdministratorController.Find(Int32.Parse(Session["Administrator"].ToString()));
        }
        protected void MemberButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/ManageMember.aspx");
        }
        protected void EmployeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/ManageEmployee.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("Administrator") != null)
            {
                Response.Cookies.Set(AdministratorController.Clear());
            }
            Session.Abandon();
            Response.Redirect("~/Views/Administrator/Login.aspx");
        }

    }
}
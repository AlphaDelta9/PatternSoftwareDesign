using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Member
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Employee"] != null || Session["Administrator"] != null)
            {
                Session.Clear();
            }
            if (Session["Member"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            UsernameLabel.Text = MemberController.FindMember(Int32.Parse(Session["Member"].ToString())).MemberName;
        }
        protected void FlowersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Flowers.aspx");
        }
        protected void HistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/History.aspx");
        }
        
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("Member") != null)
            {
                Response.Cookies.Set(GuestController.Clear());
            }
            Session.Abandon();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}
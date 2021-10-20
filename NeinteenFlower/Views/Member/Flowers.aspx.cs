using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Member
{
    public partial class Flowers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee"] != null || Session["Administrator"] != null)
            {
                Session.Clear();
            }
            if (Session["Member"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            FlowerGridView.DataSource = MemberController.GetFlower();
            FlowerGridView.DataBind();
        }
        protected void FlowerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Redirect("~/Views/Member/Order.aspx?Id=" + Int32.Parse(FlowerGridView.Rows[e.RowIndex].Cells[0].Text));
        }
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}
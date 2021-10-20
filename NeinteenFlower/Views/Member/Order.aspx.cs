using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Member
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee"] != null || Session["Administrator"] != null)
            {
                Session.Clear();
            }
            if (Session["Member"] == null || Request["Id"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }
        protected void OrderButton_Click(object sender, EventArgs e)
        {
            QuantityCheckLabel.Text = MemberController.QuantityCheck(QuantityTextBox.Text = QuantityTextBox.Text.Trim());
            if (QuantityCheckLabel.Text.Length < 1)
            {
                if (MemberController.OrderFlower(Int32.Parse(Request["Id"]), QuantityTextBox.Text, Session["Member"].ToString()))
                {
                    Response.Redirect("~/Views/Member/Flowers.aspx");
                }
                //else MITM
            }
        }
    }
}
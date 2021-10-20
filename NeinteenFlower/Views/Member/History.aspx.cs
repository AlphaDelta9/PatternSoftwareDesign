using NeinteenFlower.Controllers;
using NeinteenFlower.DataSet;
using NeinteenFlower.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Member
{
    public partial class History : System.Web.UI.Page
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
            TransactionsReport Report = new TransactionsReport();
            Report.SetDataSource(MemberController.Where(Int32.Parse(Session["Member"].ToString())));
            TransactionsReportViewer.ReportSource = Report;
        }
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}
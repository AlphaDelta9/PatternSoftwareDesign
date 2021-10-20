using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class ManageMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member"] != null || Session["Employee"] != null)
            {
                Session.Clear();
            }
            if (Session["Administrator"] == null)
            {
                Response.Redirect("~/Views/Administrator/Login.aspx");
            }
            MemberGridView.DataSource = AdministratorController.GetMember();
            MemberGridView.DataBind();
        }

        protected void MemberButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/InsertMember.aspx");
        }

        protected void MemberGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/Views/Administrator/UpdateMember.aspx?Id=" + Int32.Parse(MemberGridView.Rows[e.NewEditIndex].Cells[0].Text));
        }

        protected void MemberGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdministratorController.DeleteMember(Int32.Parse(MemberGridView.Rows[e.RowIndex].Cells[0].Text));
            Response.Redirect("~/Views/Administrator/ManageMember.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/Home.aspx");
        }
    }
}
using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class ManageEmployee : System.Web.UI.Page
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
            EmployeeGridView.DataSource = AdministratorController.GetEmployee();
            EmployeeGridView.DataBind();
        }

        protected void EmployeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/InsertEmployee.aspx");
        }

        protected void EmployeeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/Views/Administrator/UpdateEmployee.aspx?Id=" + Int32.Parse(EmployeeGridView.Rows[e.NewEditIndex].Cells[0].Text));
        }

        protected void EmployeeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdministratorController.DeleteEmployee(Int32.Parse(EmployeeGridView.Rows[e.RowIndex].Cells[0].Text));
            Response.Redirect("~/Views/Administrator/ManageEmployee.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrator/Home.aspx");
        }
    }
}
using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Employee
{
    public partial class ManageFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member"] != null || Session["Administrator"] != null)
            {
                Session.Clear();
            }
            if (Session["Employee"] == null)
            {
                Response.Redirect("~/Views/Employee/Login.aspx");
            }
            FlowerGridView.DataSource = EmployeeController.GetFlower();
            FlowerGridView.DataBind();
        }
        protected void FlowerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Employee/InsertFlower.aspx");
        }
        protected void FlowerGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/Views/Employee/UpdateFlower.aspx?Id=" + Int32.Parse(FlowerGridView.Rows[e.NewEditIndex].Cells[0].Text));
        }
        protected void FlowerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmployeeController.DeleteFlower(Int32.Parse(FlowerGridView.Rows[e.RowIndex].Cells[0].Text));
            Response.Redirect("~/Views/Employee/ManageFlower.aspx");
        }
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Employee/Home.aspx");
        }
    }
}
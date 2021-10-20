using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Employee
{
    public partial class InsertFlower : System.Web.UI.Page
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
        }
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            NameCheckLabel.Text = EmployeeController.NameCheck(NameTextBox.Text = NameTextBox.Text.Trim());
            ImageCheckLabel.Text = EmployeeController.ImageCheck(ImageFileUpload);
            DescriptionCheckLabel.Text = EmployeeController.DescriptionCheck(DescriptionTextBox.Text = DescriptionTextBox.Text.Trim());
            TypeCheckLabel.Text = EmployeeController.TypeCheck(TypeTextBox.Text = TypeTextBox.Text.Trim());
            PriceCheckLabel.Text = EmployeeController.PriceCheck(PriceTextBox.Text = PriceTextBox.Text.Trim());
            if (NameCheckLabel.Text.Length < 1 && ImageCheckLabel.Text.Length < 1 && DescriptionCheckLabel.Text.Length < 1 && TypeCheckLabel.Text.Length < 1 && PriceCheckLabel.Text.Length < 1)
            {
                if (EmployeeController.InsertFlower(NameTextBox.Text, TypeTextBox.Text, DescriptionTextBox.Text, PriceTextBox.Text, ImageFileUpload))
                {
                    Response.Redirect("~/Views/Employee/ManageFlower.aspx");
                }
                //else MITM
            }
        }
    }
}
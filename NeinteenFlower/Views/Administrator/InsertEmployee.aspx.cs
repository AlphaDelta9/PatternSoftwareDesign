using NeinteenFlower.Controllers;
using NeinteenFlower.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class InsertEmployee : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                GenderDropDownList.DataSource = AdministratorController.GenderData();
                GenderDropDownList.DataBind();
                DOBTextBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }
        protected void GenderDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = AdministratorController.EmployeeEmailCheck(EmailTextBox.Text=EmailTextBox.Text.Trim());
            PasswordCheckLabel.Text = AdministratorController.PasswordCheck(PasswordTextBox.Text=PasswordTextBox.Text.Trim());
            NameCheckLabel.Text = AdministratorController.NameCheck(NameTextBox.Text=NameTextBox.Text.Trim());
            DOBCheckLabel.Text = AdministratorController.AgeCheck(DOBTextBox.Text);
            GenderCheckLabel.Text = AdministratorController.GenderCheck(GenderDropDownList.SelectedValue[0].ToString());
            PhoneCheckLabel.Text = AdministratorController.PhoneCheck(PhoneTextBox.Text=PhoneTextBox.Text.Trim());
            AddressCheckLabel.Text = AdministratorController.AddressCheck(AddressTextBox.Text=AddressTextBox.Text.Trim());
            SalaryCheckLabel.Text = AdministratorController.SalaryCheck(SalaryTextBox.Text=SalaryTextBox.Text.Trim());
            if(EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1 && NameCheckLabel.Text.Length < 1 && DOBCheckLabel.Text.Length < 1 && GenderCheckLabel.Text.Length < 1 && PhoneCheckLabel.Text.Length < 1 && AddressCheckLabel.Text.Length < 1 && SalaryCheckLabel.Text.Length < 1)
            {
                if(AdministratorController.InsertEmployee(NameTextBox.Text, DOBTextBox.Text, GenderDropDownList.SelectedValue[0].ToString(), AddressTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, SalaryTextBox.Text, PasswordTextBox.Text))
                {
                    Response.Redirect("~/Views/Administrator/ManageEmployee.aspx");
                }
                //else MITM
            }
        }
    }
}
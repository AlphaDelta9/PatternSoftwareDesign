using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member"] != null)
            {
                Response.Redirect("~/Views/Member/Home.aspx");
            }
            else if (Session["Employee"] != null)
            {
                Response.Redirect("~/Views/Employee/Home.aspx");
            }
            else if (Session["Administrator"] != null)
            {
                Response.Redirect("~/Views/Administrator/Home.aspx");
            }
            if (!IsPostBack)
            {
                List<String> Gender = new List<String>();
                Gender.Add(" ");
                Gender.Add("Male");
                Gender.Add("Female");
                GenderDropDownList.DataSource = Gender;
                GenderDropDownList.DataBind();
            }
        }
        protected void GenderDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = GuestController.MemberEmailCheck(EmailTextBox.Text = EmailTextBox.Text.Trim());
            PasswordCheckLabel.Text = GuestController.PasswordCheck(PasswordTextBox.Text = PasswordTextBox.Text.Trim());
            NameCheckLabel.Text = GuestController.NameCheck(NameTextBox.Text = NameTextBox.Text.Trim());
            DOBCheckLabel.Text = GuestController.AgeCheck(DOBTextBox.Text);
            GenderCheckLabel.Text = GuestController.GenderCheck(GenderDropDownList.SelectedValue[0].ToString());
            PhoneCheckLabel.Text = GuestController.PhoneCheck(PhoneTextBox.Text = PhoneTextBox.Text.Trim());
            AddressCheckLabel.Text = GuestController.AddressCheck(AddressTextBox.Text = AddressTextBox.Text.Trim());
            if (EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1 && NameCheckLabel.Text.Length < 1 && DOBCheckLabel.Text.Length < 1 && GenderCheckLabel.Text.Length < 1 && PhoneCheckLabel.Text.Length < 1 && AddressCheckLabel.Text.Length < 1)
            {
                if (GuestController.InsertMember(NameTextBox.Text, DOBTextBox.Text, GenderDropDownList.SelectedValue[0].ToString(), AddressTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text))
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
                //else MITM
            }
        }
    }
}
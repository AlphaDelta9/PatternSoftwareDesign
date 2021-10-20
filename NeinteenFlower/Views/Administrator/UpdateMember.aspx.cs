using NeinteenFlower.Controllers;
using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class UpdateMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member"] != null || Session["Employee"] != null)
            {
                Session.Clear();
            }
            if (Session["Administrator"] == null || Request["Id"] == null)
            {
                Response.Redirect("~/Views/Administrator/Login.aspx");
            }
            if (!IsPostBack)
            {
                GenderDropDownList.DataSource = AdministratorController.GenderData();
                GenderDropDownList.DataBind();
                MsMember Member = AdministratorController.FindMember(Int32.Parse(Request["Id"]));
                EmailTextBox.Text = Member.MemberEmail;
                NameTextBox.Text = Member.MemberName;
                DOBTextBox.Text = Member.MemberDOB.ToString("yyyy-MM-dd");
                if (Member.MemberGender.Equals("M"))
                {
                    GenderDropDownList.SelectedIndex = 1;
                }
                else
                {
                    GenderDropDownList.SelectedIndex = 2;
                }
                PhoneTextBox.Text = Member.MemberPhone;
                AddressTextBox.Text = Member.MemberAddress;
            }
        }
        protected void GenderDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = AdministratorController.MemberEmailCheckUpdate(EmailTextBox.Text = EmailTextBox.Text.Trim(), Int32.Parse(Request["Id"]));
            PasswordCheckLabel.Text = AdministratorController.PasswordCheck(PasswordTextBox.Text = PasswordTextBox.Text.Trim());
            NameCheckLabel.Text = AdministratorController.NameCheck(NameTextBox.Text = NameTextBox.Text.Trim());
            DOBCheckLabel.Text = AdministratorController.AgeCheck(DOBTextBox.Text);
            GenderCheckLabel.Text = AdministratorController.GenderCheck(GenderDropDownList.SelectedValue[0].ToString());
            PhoneCheckLabel.Text = AdministratorController.PhoneCheck(PhoneTextBox.Text = PhoneTextBox.Text.Trim());
            AddressCheckLabel.Text = AdministratorController.AddressCheck(AddressTextBox.Text = AddressTextBox.Text.Trim());
            if (EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1 && NameCheckLabel.Text.Length < 1 && DOBCheckLabel.Text.Length < 1 && GenderCheckLabel.Text.Length < 1 && PhoneCheckLabel.Text.Length < 1 && AddressCheckLabel.Text.Length < 1)
            {
                if (AdministratorController.UpdateMember(Int32.Parse(Request["Id"]), NameTextBox.Text, DOBTextBox.Text, GenderDropDownList.SelectedValue[0].ToString(), AddressTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text))
                {
                    Response.Redirect("~/Views/Administrator/ManageMember.aspx");
                }
                //else MITM
            }
        }
    }
}
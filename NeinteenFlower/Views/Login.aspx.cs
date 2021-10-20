using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Member"] != null)
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
            if (Request.Cookies.Get("Member") != null)
            {
                RememberCheckBox.Checked = true;
                EmailTextBox.Text = Request.Cookies.Get("Member").Values.Get("Email");
                PasswordTextBox.Attributes["value"] = Request.Cookies.Get("Member").Values.Get("Password");
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = GuestController.EmailVerify(EmailTextBox.Text = EmailTextBox.Text.Trim());
            PasswordCheckLabel.Text = GuestController.PasswordCheck(PasswordTextBox.Text = PasswordTextBox.Text.Trim());
            if (EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1)
            {
                PasswordCheckLabel.Text = GuestController.PasswordVerify(EmailTextBox.Text, PasswordTextBox.Text);
                if (PasswordCheckLabel.Text.Length < 1)
                {
                    if (RememberCheckBox.Checked && Request.Cookies.Get("Member") == null)
                    {
                        Response.Cookies.Set(GuestController.Remember(EmailTextBox.Text, PasswordTextBox.Text));
                    }
                    Session["Member"] = GuestController.Where(EmailTextBox.Text).MemberId;
                    Response.Redirect("~/Views/Member/Home.aspx");
                }
            }
        }

        protected void ForgetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ForgetPassword.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }
    }
}
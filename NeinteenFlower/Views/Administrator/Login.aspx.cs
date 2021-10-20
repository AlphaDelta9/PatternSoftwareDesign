using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views.Administrator
{
    public partial class Login : System.Web.UI.Page
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
            if (Request.Cookies.Get("Administrator") != null)
            {
                RememberCheckBox.Checked = true;
                EmailTextBox.Text = Request.Cookies.Get("Administrator").Values.Get("Email");
                PasswordTextBox.Attributes["value"] = Request.Cookies.Get("Administrator").Values.Get("Password");
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = AdministratorController.EmailVerify(EmailTextBox.Text = EmailTextBox.Text.Trim());
            PasswordCheckLabel.Text = AdministratorController.PasswordCheck(PasswordTextBox.Text = PasswordTextBox.Text.Trim());
            if (EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1)
            {
                PasswordCheckLabel.Text = AdministratorController.PasswordVerify(EmailTextBox.Text, PasswordTextBox.Text);
                if (PasswordCheckLabel.Text.Length < 1)
                {
                    if (RememberCheckBox.Checked && Request.Cookies.Get("Administrator") == null)
                    {
                        Response.Cookies.Set(AdministratorController.Remember(EmailTextBox.Text, PasswordTextBox.Text));
                    }
                    Session["Administrator"] = AdministratorController.Where(EmailTextBox.Text);
                    Response.Redirect("~/Views/Administrator/Home.aspx");
                }
            }
        }
    }
}
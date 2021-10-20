using NeinteenFlower.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Views
{
    public partial class ForgetPassword : System.Web.UI.Page
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
                CaptchaTextBox.Text = GuestController.GetCaptcha();
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            EmailCheckLabel.Text = GuestController.ResetEmailCheck(EmailTextBox.Text = EmailTextBox.Text.Trim());
            PasswordCheckLabel.Text = GuestController.CaptchaCheck(PasswordTextBox.Text = PasswordTextBox.Text.Trim(),CaptchaTextBox.Text);
            if (EmailCheckLabel.Text.Length < 1 && PasswordCheckLabel.Text.Length < 1)
            {
                if (GuestController.UpdatePassword(EmailTextBox.Text, PasswordTextBox.Text))
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }
    }
}
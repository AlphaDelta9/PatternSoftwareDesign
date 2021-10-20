<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="NeinteenFlower.Views.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="EmailCheckLabel" runat="server" Text=""></asp:Label>
        </div>
            <asp:Label ID="CaptchaLabel" runat="server" Text="Captcha"></asp:Label>
            <asp:TextBox ID="CaptchaTextBox" runat="server" ReadOnly="true"></asp:TextBox>
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:Label ID="PasswordCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click" />
        </div>
    </form>
</body>
</html>

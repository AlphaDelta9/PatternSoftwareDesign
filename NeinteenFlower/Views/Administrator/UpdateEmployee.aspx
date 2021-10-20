<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="NeinteenFlower.Views.Administrator.UpdateEmployee" %>

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
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:Label ID="PasswordCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="NameCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="DOBLabel" runat="server" Text="DOB"></asp:Label>
            <asp:TextBox ID="DOBTextBox" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Label ID="DOBCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="GenderDropDownList" runat="server" OnSelectedIndexChanged="GenderDropDownList_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="GenderCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="PhoneLabel" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="PhoneCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="AddressTextBox" runat="server" ></asp:TextBox>
            <asp:Label ID="AddressCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="SalaryLabel" runat="server" Text="Salary"></asp:Label>
            <asp:TextBox ID="SalaryTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="SalaryCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="UpdateButton" runat="server" Text="Update Employee" OnClick="UpdateButton_Click" />
        </div>
    </form>
</body>
</html>

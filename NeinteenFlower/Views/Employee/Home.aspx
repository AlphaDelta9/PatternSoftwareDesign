<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NeinteenFlower.Views.Employee.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Button ID="FlowerButton" runat="server" Text="Manage Flower" OnClick="FlowerButton_Click" />
        </div>
        <div>
            <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NeinteenFlower.Views.Member.Home" %>

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
            <asp:Button ID="FlowersButton" runat="server" Text="Pre Order" OnClick="FlowersButton_Click" />
            <asp:Button ID="HistoryButton" runat="server" Text="Transactions History" OnClick="HistoryButton_Click" />
        </div>
        <div>
            <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="NeinteenFlower.Views.Member.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="QuantityLabel" runat="server" Text="Quantity"></asp:Label>
            <asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="QuantityCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="OrderButton" runat="server" Text="Order Flower" OnClick="OrderButton_Click" />
        </div>
    </form>
</body>
</html>

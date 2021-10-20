<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateFlower.aspx.cs" Inherits="NeinteenFlower.Views.Employee.UpdateFlower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="NameCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="ImageLabel" runat="server" Text="Image"></asp:Label>
            <asp:FileUpload ID="ImageFileUpload" runat="server" />
            <asp:Label ID="ImageCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="DescriptionLabel" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="DescriptionTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="DescriptionCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="TypeLabel" runat="server" Text="Type"></asp:Label>
            <asp:TextBox ID="TypeTextBox" runat="server" ></asp:TextBox>
            <asp:Label ID="TypeCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="PriceCheckLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="UpdateButton" runat="server" Text="Update Flower" OnClick="UpdateButton_Click" />
        </div>
    </form>
</body>
</html>

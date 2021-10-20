<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFlower.aspx.cs" Inherits="NeinteenFlower.Views.Employee.ManageFlower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="FlowerButton" runat="server" Text="Insert Flower" OnClick="FlowerButton_Click" />
            <asp:Button ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" />
            <asp:GridView ID="FlowerGridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="FlowerGridView_RowDeleting" OnRowEditing="FlowerGridView_RowEditing">
                <Columns>
                    <asp:BoundField DataField="FlowerId" HeaderText="Id" />
                    <asp:BoundField DataField="FlowerName" HeaderText="Name" />
                    <asp:BoundField DataField="FlowerImage" HeaderText="Image" />
                    <asp:BoundField DataField="FlowerDescription" HeaderText="Description" />
                    <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="Type" />
                    <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Action"  />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

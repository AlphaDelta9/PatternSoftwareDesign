<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flowers.aspx.cs" Inherits="NeinteenFlower.Views.Member.Flowers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" />
            <asp:GridView ID="FlowerGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="FlowerGridView_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="FlowerId" HeaderText="Id" />
                    <asp:BoundField DataField="FlowerName" HeaderText="Name" />
                    <asp:BoundField DataField="FlowerImage" HeaderText="Image" />
                    <asp:BoundField DataField="FlowerDescription" HeaderText="Description" />
                    <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="Type" />
                    <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
                    <asp:CommandField ShowDeleteButton="true" HeaderText="Action" DeleteText="PreOrder"  />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="NeinteenFlower.Views.Administrator.ManageMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="MemberButton" runat="server" Text="Insert Member" OnClick="MemberButton_Click" />
            <asp:Button ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" />
            <asp:GridView ID="MemberGridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="MemberGridView_RowDeleting" OnRowEditing="MemberGridView_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MemberId" HeaderText="Id" />
                    <asp:BoundField DataField="MemberName" HeaderText="Name" />
                    <asp:BoundField DataField="MemberDOB" HeaderText="DOB" />
                    <asp:BoundField DataField="MemberGender" HeaderText="Gender" />
                    <asp:BoundField DataField="MemberAddress" HeaderText="Address" />
                    <asp:BoundField DataField="MemberPhone" HeaderText="Phone" />
                    <asp:BoundField DataField="MemberEmail" HeaderText="Email" />
                    <asp:BoundField DataField="MemberPassword" HeaderText="Password" />
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Action"  />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

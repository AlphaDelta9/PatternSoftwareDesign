<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="NeinteenFlower.Views.Administrator.ManageEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="EmployeeButton" runat="server" Text="Insert Employee" OnClick="EmployeeButton_Click" />
            <asp:Button ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" />
            <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="EmployeeGridView_RowDeleting" OnRowEditing="EmployeeGridView_RowEditing">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                    <asp:BoundField DataField="EmployeeDOB" HeaderText="DOB" />
                    <asp:BoundField DataField="EmployeeGender" HeaderText="Gender" />
                    <asp:BoundField DataField="EmployeeAddress" HeaderText="Address" />
                    <asp:BoundField DataField="EmployeePhone" HeaderText="Phone" />
                    <asp:BoundField DataField="EmployeeEmail" HeaderText="Email" />
                    <asp:BoundField DataField="EmployeeSalary" HeaderText="Salary" />
                    <asp:BoundField DataField="EmployeePassword" HeaderText="Password" />
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Action"  />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

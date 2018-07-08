<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DARHMethods.aspx.cs" Inherits="WebApplication1.DisDataAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 88%;
        }
        .auto-style3 {
            width: 303px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 185px;
            text-align: center;
        }
        .auto-style6 {
            width: 303px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Georgia, 'Times New Roman', Times, serif">
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">
            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" OnClick="btnGetDataFromDB_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Undo" />
                        <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Row State" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="AcceptChanges" />
                    </td>
                    <td class="auto-style6">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" style="height: 146px; width: 441px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
                    </td>
                    <td class="auto-style4">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
            <asp:Button ID="btnUpdateDatabaseTable" runat="server" Text="Update Database Table" OnClick="btnUpdateDatabaseTable_Click" />
                    </td>
                    <td class="auto-style6">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>

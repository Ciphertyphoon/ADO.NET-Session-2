<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLInjectionPrevention.aspx.cs" Inherits="Sample_ADO.NetWebApplication.SQLInjectionPrevention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="ProductNameTextBox" runat="server" Width="175px"></asp:TextBox>
            <asp:Button ID="GetProductsButton" runat="server" BackColor="#993366" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="2px" OnClick="GetProductsButton_Click" Text="Get Products" />
            <asp:GridView ID="ProductsGridView" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            <br />

        </div>
    </form>
</body>
</html>

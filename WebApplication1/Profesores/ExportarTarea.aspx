<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTarea.aspx.vb" Inherits="WebApplication1.ExportarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div style="text-align:center;background-color:Highlight;">
        <h1 style="color:lightcyan">EXPORTAR TAREAS<asp:Label ID="Label1" runat="server" Text=" "></asp:Label></h1>
    </div>
    <div style="text-align:center; margin-left:auto; margin-right:auto">
        <form id="formExportar" runat="server">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Exportar XML"  style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" />
            <asp:Button ID="Button2" runat="server" Text="Exportar JSON"  style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" />
            <br />

            <asp:Label ID="Label2" runat="server"  Text=""></asp:Label>

            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        <br />
        </form>
        <br />
    </div>
   
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesores/Profesor.aspx">Menú profesor</asp:HyperLink>
    </p>
   
</body>
</html>


<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApplication1.Profesor2" %>
<!DOCTYPE html>
<script runat="server">
    Protected Sub LinkButton8_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Profesores/TareasProfesor.aspx")
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="cabecera" style="text-align:center;background-color:Highlight;">
            <h1 style="color:lightcyan">Bienvenido <asp:Label ID="Label1" runat="server" Text=" "></asp:Label></h1>
        </div>
        <div id="cabecera2" style="float:right;text-align:left;width:10%">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="53px" ImageUrl="https://cdn2.iconfinder.com/data/icons/snipicons/500/logout-256.png" Width="57px" />
              Logout
            </div>    
        <br /><br /><br />
        <div id="colIZQ" style="text-align:center;float:left;background-color:cornflowerblue;width:25%; height: 500px;">  
            <br /><br /><br />
                <asp:LinkButton ID="LinkButton7" style="font-size:35px" runat="server">Asignaturas</asp:LinkButton>
            <br /><br />
                <asp:LinkButton ID="LinkButton8"  style="font-size:35px" runat="server" CausesValidation="False" OnClick="LinkButton8_Click">Tareas</asp:LinkButton> 
            <br /><br />
                <asp:LinkButton ID="LinkButton9"  style="font-size:35px" runat="server">Grupos</asp:LinkButton>
            <br /><br />
                 <asp:LinkButton ID="LinkButton10"  style="font-size:35px" runat="server">Importar v. XML Document</asp:LinkButton>
            <br /><br />
                 <asp:LinkButton ID="LinkButton11"  style="font-size:35px" runat="server">Exportar</asp:LinkButton>
            <br /><br />
                <asp:LinkButton ID="LinkButton12"  style="font-size:35px" runat="server">Importar v. Dataset</asp:LinkButton>
            <br /><br />
        </div>
        <div id="columnaDER" style="text-align:center;float:right;background-color:Highlight;width:74%; height: 500px;">
            <br /><br /> <br /><br /><br />
            <h1>Gestión Web de Tareas-Dedicación</h1>
            <br /><br />
            <h1>Profesores</h1>
        </div>
    </form>
</body>
</html>

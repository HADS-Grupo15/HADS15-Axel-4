<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="WebApplication1.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Instanciar tareas alumno</title>
</head>
<body>
    <div style="text-align:center;background-color:Highlight;">
            <h1 style="color:lightcyan">INSTANCIAR TAREAS</h1>
    </div>
    <form id="form1" runat="server">
        <div style="width:250px; margin:0 auto; text-align:center" >
            <asp:Label runat="server" Text="Usuario" style="float:left"></asp:Label>
            <asp:TextBox id="txtUsuario" runat="server" style="float:right;border-color:Highlight;border-right:none;border-left:none;border-top:none" Height="18px" Enabled="False" ReadOnly="True"/>
            <br />
            <asp:Label runat="server" Text="Tarea" style="float:left"></asp:Label>
            <asp:TextBox id="txtTarea" runat="server" style="float:right;border-color:Highlight;border-right:none;border-left:none;border-top:none" Height="18px" Enabled="False" ReadOnly="True"/>
            <br />
            <asp:Label runat="server" Text="Horas est." style="float:left"></asp:Label>
            <asp:TextBox id="txtHEst" runat="server" style="float:right;border-color:Highlight;border-right:none;border-left:none;border-top:none" Height="18px" Enabled="False" ReadOnly="True"/>
            <br />
            <asp:Label runat="server" Text="Horas reales" style="float:left"></asp:Label>
            <asp:TextBox id="txtHReales" runat="server" style="float:right;border-color:Highlight;border-right:none;border-left:none;border-top:none" Height="18px"/>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtHEst" ErrorMessage="Debe ser un número no negativo" Operator="GreaterThanEqual" ValueToCompare="0" style="float:right"></asp:CompareValidator>
            <br />
            <asp:Button ID="submit" runat="server" Text="Instanciar Tarea" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/>
        </div>
        <br />
        <br />
        <p style="text-align:center">

            <asp:Label ID="Label1" runat="server"  Text=""></asp:Label>

        </p>
        <div>
            <asp:HyperLink ID="hyperTareasAlumno" runat="server" NavigateUrl="~/Alumnos/TareasAlumno.aspx">Volver a las tareas del alumno</asp:HyperLink>
        </div>
     </form>
</body>
</html>

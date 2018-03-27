<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="WebApplication1.Alumno" %>
<%@ Register Src="~/CabeceraInicio.ascx" TagPrefix="uc1" TagName="CabeceraInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel de Control: ALUMNO</title>
    <style type="text/css">
        #columnaIZQ {
            height: 550px;
        }
    </style>
</head>
<body>

<div>
<div style="text-align:center;float:left;background-color:cornflowerblue;width:25%; height: 570px;">
    <form ID="columnaIZQ" runat="server">
     <br /><br /<br /><br /><br /><br /><br /><br /><!-- AGRANDAR-->
        <asp:HyperLink ID="HLTareasGenericas" style="font-size:35px" runat="server" NavigateUrl="~/Alumnos/TareasAlumno.aspx">Tareas Genéricas</asp:HyperLink>
    <br /><br />
        <asp:HyperLink ID="HLTareasPropias"  style="font-size:35px" runat="server" NavigateUrl="">Tareas Propias</asp:HyperLink> 
    <br /><br />
     <asp:HyperLink ID="HLGrupos"  style="font-size:35px" runat="server" NavigateUrl="">Grupos</asp:HyperLink>
    <br /><br />
    </form>
</div>
<div style="text-align:center;float:right;background-color:Highlight;width:75%; height: 570px;">
    <br /><br /><br /><br /><br /><br />
    <h1>Gestión Web de Tareas-Dedicación</h1>
    <br /><br />
    <h1>Alumnos</h1>
</div>
</div>
</body>
</html>

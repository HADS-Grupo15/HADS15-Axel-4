<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="WebApplication1.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mostrar tareas Alumno</title>
</head>
<body>
        <div style="text-align:center;background-color:Highlight;">
        <h1 style="color:lightcyan">GESTIÓN DE TAREAS</h1>
    </div>  
    <form id="formTareaGen" runat="server"  style="text-align: center">
        <div>
            <p>Selecciona la asignatura</p>           
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px"/>         
        </div>
        <br /><br />
        <div>
            <asp:GridView ID="GridViewTareas" runat="server" HorizontalAlign="Center" EmptyDataText="No hay tareas de esta asignatura" 
                Height="305px" Width="786px" DataKeyNames="Codigo" AllowSorting="True" AutoGenerateSelectButton="True">
                <AlternatingRowStyle BackColor="#aed6f1" />
                <HeaderStyle BackColor="#2e86c1" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>

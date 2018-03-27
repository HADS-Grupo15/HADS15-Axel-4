<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="WebApplication1.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nueva Tarea</title>
</head>
<body><!--FALTAN LAS VALIDACIONES DE LOS CAMPOS-->
    <div style="text-align:center;background-color:Highlight;">
        <h1 style="color:lightcyan">NUEVA TAREA</h1>
    </div>
    <br /><br />
    <form id="formTareas" style="text-align:center" runat="server">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HADS-15-TareasConnectionString %>" 
                    SelectCommand="SELECT Asignaturas.codigo FROM Asignaturas INNER JOIN GruposClase ON GruposClase.codigoasig = Asignaturas.codigo INNER JOIN ProfesoresGrupo ON ProfesoresGrupo.codigogrupo = GruposClase.codigo WHERE ProfesoresGrupo.email = @email">
                    <SelectParameters>
                         <asp:SessionParameter Name="email" SessionField="UserID" />
                     </SelectParameters>
               </asp:SqlDataSource>
        <div>
            <div style="width:48%; float:left;text-align:right;font-size:25px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" controltovalidate="TextBox3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>            
            <br /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" controltovalidate="TextBox4" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>          
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Asignatura"></asp:Label>            
            <br /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" controltovalidate="TextBox1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="Label4" runat="server" Text="Horas estimadas"></asp:Label>            
            <br /><br />
            <asp:Label ID="Label5" runat="server" Text="Tipo Tarea"></asp:Label>          
            <br /><br />
        </div>
        <div style="width:48%; float:right;text-align:left;font-size:25px">            
            <asp:TextBox ID="TextBox3" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none;font-size:20px;color:dimgrey;text-align:center" Width="116px" ></asp:TextBox>
            <br /><br />           
            <asp:TextBox ID="TextBox4" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none;font-size:20px;color:dimgrey;text-align:center" Width="189px"></asp:TextBox>
            <br /><br />            
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
            <br /><br />
            <asp:TextBox ID="TextBox1" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none;width:85px;font-size:20px;color:dimgrey;text-align:center"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" controltovalidate="TextBox1" runat="server" ForeColor="Red" ErrorMessage="Ingresa un número" Font-Size="Medium" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            <br /><br />
            <asp:DropDownList ID="DropDownList4" runat="server" Height="30px" Width="111px" Font-Size="15px">
                            <asp:ListItem>Laboratorio</asp:ListItem>
                            <asp:ListItem>Ejercicio</asp:ListItem>
                            <asp:ListItem>Examen</asp:ListItem>
            </asp:DropDownList>
            <br /><br />
        </div>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <asp:Button ID="Button2" runat="server" Text="Cancelar" style="border-radius:3px" BackColor="#FF3300" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="90px" CausesValidation="False" />
            <asp:Button ID="Button1" runat="server" Text="Crear Tarea"  style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="90px"/>
            </div>
    </form>
</body>
</html>

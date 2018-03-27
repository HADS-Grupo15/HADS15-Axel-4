<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="WebApplication1.Registro" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <br /><br /><br />
    <div>  
        <h2 style="color:Highlight;text-align:center">REGISTRO DE USUARIOS</h2>
        <form id="formReg" runat="server" ><br /><br />
            <div>
             <div style="width:47%; float:left;text-align:right;">
                <h3>Datos personales</h3><br /><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNom" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblNom" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNom" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox><br /><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApe" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblApe" runat="server" Text="Primer Apellido: "></asp:Label>
                <asp:TextBox ID="txtApe" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox><br /><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApe2" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblApe2" runat="server" Text="Segundo Apellido: "></asp:Label>
                <asp:TextBox ID="txtApe2" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox><br /><br />
                <asp:Label ID="lblRol" runat="server" Text="Escoja un rol: "></asp:Label>
                <asp:DropDownList ID="rol" runat="server" Height="21px" Width="143px">
                    <asp:ListItem Selected="True">Alumno</asp:ListItem>
                    <asp:ListItem>Profesor</asp:ListItem>
                </asp:DropDownList>
              </div> 
              <div style="width:47%;float:right; text-align:left">
                <h3>Datos de inicio</h3><br /><br />
                <asp:Label ID="lblMail" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txtmail" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmail" ErrorMessage="Formato mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  <br /><br />
                <asp:Label ID="lblPass" runat="server" Text="Contraseña: "></asp:Label>
                  <asp:TextBox ID="txtPass" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none" TextMode="Password"/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPass" ErrorMessage="*"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPass" ErrorMessage="Debe contener de 4 a 12 caracteres" ValidationExpression="\w{4,12}"></asp:RegularExpressionValidator>
                  <br /><br />
                <asp:Label ID="lblPass2" runat="server" Text="Confirmar contraseña: "></asp:Label>
               <asp:TextBox ID="txtPass2" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none" TextMode="Password"/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPass2" ErrorMessage="*"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtPass2" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                  <br /><br />
             </div>
               <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                <p style="text-align:center">
                    <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/>
                </p>
          </div>
        </form> 
    </div>
    <p style="text-align:center">
        <asp:Label ID="txtConfirmar" runat="server"></asp:Label><br />
    </p>  
</body>
</html>

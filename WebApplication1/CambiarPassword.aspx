<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword.aspx.vb" Inherits="WebApplication1.PassChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">¿HAS OLVIDADO TU CONTRASEÑA?</h2>
        <h3>Introduce el correo que utilizaste al crear la cuenta,</h3>
        <h3>te mandaremos un código para proceder con el cambio de contraseña</h3>
    <form id="formPassChange1" runat="server" ><br /><br />
        <asp:Label ID="lblMail" runat="server" Text="Correo electrónico:" style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtMail" runat="server" Width="186px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMail" ErrorMessage="Formato mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br /><br />
        <br /><br />
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
    <div>
         <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="hyperPass" runat="server" NavigateUrl="~/Inicio.aspx">Ir a página de Login</asp:HyperLink><br /><br />
        <br />
    </div>
        </form>
   </div>
</body>
</html>

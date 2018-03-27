<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">INICIAR SESIÓN</h2>
    <form id="formLogin" runat="server" ><br /><br />
        <asp:Label ID="lblMail" runat="server" Text="Correo electrónico:" style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtMail" runat="server" Width="186px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Formato mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Label ID="lblPass" runat="server" style="font-size:larger;" Text="Contraseña:"></asp:Label><br /><br />
        <asp:TextBox ID="txtPass" runat="server" style="border-color:Highlight;border-right:none;border-left:none;border-top:none" TextMode="Password"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtPass" ErrorMessage="Debe contener de 4 a 12 caracteres"></asp:CustomValidator>
        <br /><br />
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
        </form>
        <br />
        <p style="text-align:center">
            <asp:Label ID="lblAns" runat="server"></asp:Label>
        </p>
    <div>
        <asp:HyperLink ID="hyperPass" runat="server" PostBackUrl="~/Registro.aspx" NavigateUrl="CambiarPassword.aspx">¿Has olvidado tu contraseña?</asp:HyperLink><br /><br />
        <asp:HyperLink ID="hyperRegister" runat="server" PostBackUrl="~/Registro.aspx" NavigateUrl="Registro.aspx" >¿Aún no te has registrado?</asp:HyperLink><br />
    </div>
   </div>
</body>
</html>

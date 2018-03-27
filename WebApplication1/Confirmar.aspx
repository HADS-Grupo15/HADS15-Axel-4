<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="WebApplication1.ConfirmAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">CONFIRMAR CUENTA</h2>
        <h3 style="color:darkgreen">Enhorabuena, te has registrado satisfactoriamente</h3>
        <h3 style="color: darkgreen">Por favor, revisa tu correo e indica el código que se te ha facilitado</h3>
    <form id="formConfirm" runat="server" ><br /><br />
        <asp:Label ID="lblCode" runat="server" style="font-size:larger;" Text="Código de confirmación:"></asp:Label><br /><br />
        <asp:TextBox ID="txtCod" runat="server" Width="146px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCod" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
        </form>
    <div>
        <br />
         <asp:Label ID="Label1" runat="server"></asp:Label>
        <br /><br />
        <asp:HyperLink ID="hyperPass" runat="server" NavigateUrl="~/Inicio.aspx">Ir a página de Login</asp:HyperLink><br />
    </div>
   </div>
</body>
</html>

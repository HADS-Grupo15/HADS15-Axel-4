<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CabeceraInicio.ascx.vb" Inherits="WebApplication1.CabeceraInicio" %>
<br /><br />
<div id="SessionID" style="float:left;width:69%;">
    <!-- aqui la cabecera y el mensaje-->
    <asp:Label ID="lblMsg" runat="server" Text="Bienvenido de nuevo "/><!-- darle fuente y formato-->
    <asp:Label ID="lblUserID" runat="server" Text=""/>
</div>
<div id ="Logout" style="float:right;width:27%;text-align:center">
    <!-- Aqui meteremos el boton de logout -->
    <asp:Button ID="submit" runat="server" Text="Logout" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/>
</div>
<br />
<div style="border-bottom:double; border-bottom-color:Highlight;"/>


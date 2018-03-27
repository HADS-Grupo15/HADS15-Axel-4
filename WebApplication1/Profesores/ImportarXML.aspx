<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarXML.aspx.vb" Inherits="WebApplication1.ImportarXML" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Importar XML</title>
</head>
<body>
    <div style="text-align:center;background-color:Highlight;">
        <h1 style="color:lightcyan">IMPORTAR TAREAS XML</h1>
    </div>
    <form id="form1" runat="server">
        <div style="width:17%; float:left;text-align:right;">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="https://i.imgur.com/hxHRLGM.png" Width="69px" ForeColor="#0099FF" OnClick="ImageButton1_Click" />
        </div>
        <div style="width:17%; float:right;text-align:left;">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="53px" ImageUrl="https://cdn2.iconfinder.com/data/icons/snipicons/500/logout-256.png" Width="57px" />
        </div>
        <div id="DataSourceDiv">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-15-TareasConnectionString %>" SelectCommand="SELECT Asignaturas.codigo as Asignaturas FROM Asignaturas 
INNER JOIN GruposClase ON GruposClase.codigoasig = Asignaturas.codigo 
INNER JOIN ProfesoresGrupo ON ProfesoresGrupo.codigogrupo = GruposClase.codigo
WHERE ProfesoresGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="UserID" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div id="in" style="text-align:center;font-size:25px" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Seleccione una asignatura:"></asp:Label><br /><br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="95px" DataSourceID="SqlDataSource1" AutoPostBack="True"  DataTextField="Asignaturas" DataValueField="Asignaturas"></asp:DropDownList><br />    
            <br />
            <asp:Button ID="btnImportar" runat="server" Text="Importar XML"  style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="125px" Visible="False"/>

            </div>
        <br />
        <hr />
        <div id="XML">
            <asp:Xml ID="xml" runat="server"></asp:Xml>
        </div>
        <div id="divSort" style="text-align:center;font-size:18px" runat="server" visible="false">
            <p>¿Deseas ordenar por algún parámetro?</p>
            <asp:Button ID="btnSortCod" runat="server" Text="Código" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="90px"/>
            <asp:Button ID="btnSortDesc" runat="server" Text="Descripción" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="90px"/>
            <asp:Button ID="btnSortHE" runat="server" Text="HEstimadas" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px" Width="90px"/>
        </div>
        <div style="text-align:center">
            <asp:Label ID="lblInfo" runat="server" Text=" "></asp:Label>
        </div>       
        <br /><hr />
        <div id="DataSetDiv">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

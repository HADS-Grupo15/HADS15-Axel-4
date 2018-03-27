Imports System.Data.SqlClient

Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(
        "Server=tcp: hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID = opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapTareasProfesor As New SqlDataAdapter()

    Dim dtsTareasProfesor As New DataSet

    Dim tblTareasProfesor As New DataTable

    Dim rowTareasProfesor As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserID") = "blanco@ehu.es"

        If Page.IsPostBack Then

            dtsTareasProfesor = Session("TareasProfesor")

        Else

            dapTareasProfesor = New SqlDataAdapter("SELECT * FROM TareasGenericas WHERE CodAsig='" & DropDownList3.SelectedValue & "'", conexion)

            Dim bldTareasUser As New SqlCommandBuilder(dapTareasProfesor)

            dapTareasProfesor.Fill(dtsTareasProfesor, "TareasProfesor")

            tblTareasProfesor = dtsTareasProfesor.Tables("TareasProfesor")

            Session("TareasProfesor") = dtsTareasProfesor

            Session("AdapterTareasProfesor") = dapTareasProfesor

        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            tblTareasProfesor = dtsTareasProfesor.Tables("TareasProfesor")

            rowTareasProfesor = tblTareasProfesor.NewRow()

            '-------------------------------------------------

            rowTareasProfesor("Codigo") = TextBox3.Text

            rowTareasProfesor("Descripcion") = TextBox4.Text

            rowTareasProfesor("CodAsig") = DropDownList3.SelectedValue

            rowTareasProfesor("HEstimadas") = TextBox1.Text

            rowTareasProfesor("Explotacion") = False '<!--Preguntar valor por defecto-->

            rowTareasProfesor("TipoTarea") = DropDownList4.SelectedValue

            '-------------------------------------------------

            tblTareasProfesor.Rows.Add(rowTareasProfesor)

            dapTareasProfesor = Session("AdapterTareasProfesor")

            dapTareasProfesor.Update(dtsTareasProfesor, "TareasProfesor")

            dtsTareasProfesor.AcceptChanges()

            'que muestre una ventana  y al acepptar redireccione!!!!NO FUNCIONA! EL RESPONSE REDIRECT SE LO COME

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Tarea creada!');window.location ='./TareasProfesor.aspx';", True)

            ' Response.Redirect("./TareasProfesor.aspx")


        Catch

            'ventana que muestre el error(?)

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Ha ocurrido un error!')", True)


        End Try

    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged

        dapTareasProfesor = New SqlDataAdapter("SELECT * FROM TareasGenericas WHERE CodAsig='" & DropDownList3.SelectedValue & "'", conexion)

        Dim bldTareasUser As New SqlCommandBuilder(dapTareasProfesor)

        dapTareasProfesor.Fill(dtsTareasProfesor, "TareasProfesor")

        tblTareasProfesor = dtsTareasProfesor.Tables("TareasProfesor")

        Session("TareasProfesor") = dtsTareasProfesor

        Session("AdapterTareasProfesor") = dapTareasProfesor

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("./TareasProfesor.aspx")

    End Sub

End Class
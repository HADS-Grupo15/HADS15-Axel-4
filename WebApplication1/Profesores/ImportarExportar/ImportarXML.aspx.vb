Imports System.Data.SqlClient
Imports System.Xml

Public Class ImportarXML
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(
        "Server=tcp: hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID = opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapTareas As New SqlDataAdapter()

    Dim dtsTareas As New DataSet

    Dim dtblTareas As New DataTable

    Dim rowTareas As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserID") = "blanco@ehu.es"

        'AÑADIR CONTROL DE POSTBACK!!!

        If Me.IsPostBack Then

            dtsTareas = Session("Tareas")

            adapTareas = Session("adapT")

        Else

            adapTareas = New SqlDataAdapter("SELECT * FROM TareasGenericas", conexion)

            Dim bld As New SqlCommandBuilder(adapTareas)

            adapTareas.Fill(dtsTareas, "Tareas")

            Session("Tareas") = dtsTareas

            Session("adapT") = adapTareas

        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim found As Boolean

        found = System.IO.File.Exists(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")) 'HAS.xml // SEG.xml

        If found Then

            If btnImportar.Visible = False Then

                btnImportar.Visible = True ' AQUI

            End If

            divSort.Visible = True

            xml.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")

            xml.TransformSource = Server.MapPath("~/App_Data/XSLTFile.xsl")

        Else

            divSort.Visible = False

            btnImportar.Visible = False

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Revisa el fichero de Origen!')", True)

        End If

    End Sub

    Protected Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        Dim xml As New XmlDocument

        xml.Load(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml"))

        Dim nodosT As XmlNodeList

        nodosT = xml.GetElementsByTagName("tarea") 'si sigue petando probar con "Tarea"

        Dim row As DataRow

        For i = 0 To nodosT.Count - 1

            row = dtsTareas.Tables(0).NewRow()

            row.Item("Codigo") = nodosT(i).Attributes(0).Value

            row.Item("Descripcion") = nodosT(i).ChildNodes(0).ChildNodes(0).Value

            row.Item("CodAsig") = DropDownList1.SelectedValue

            row.Item("HEstimadas") = nodosT(i).ChildNodes(1).ChildNodes(0).Value

            row.Item("Explotacion") = nodosT(i).ChildNodes(2).ChildNodes(0).Value

            row.Item("TipoTarea") = nodosT(i).ChildNodes(3).ChildNodes(0).Value

            dtsTareas.Tables(0).Rows.Add(row)

        Next

        Try
            adapTareas.Update(dtsTareas, dtsTareas.Tables(0).TableName)

            dtsTareas.AcceptChanges()

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Datos almacenados con éxito!')", True)

        Catch ex As SqlException

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Los datos ya se encontraban cargados!')", True)

        End Try

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Response.Redirect("~/Profesores/Profesor.aspx")

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        FormsAuthentication.SignOut()
        Session.Abandon()

        Response.Redirect("~/Inicio.aspx")

    End Sub


    '--------OPCIONAL-------------'

    Protected Sub btnSortCod_Click(sender As Object, e As EventArgs) Handles btnSortCod.Click

        xml.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("~/App_Data/XSLTCodigo.xslt")

    End Sub

    Protected Sub btnSortDesc_Click(sender As Object, e As EventArgs) Handles btnSortDesc.Click

        xml.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("~/App_Data/XSLTDescripcion.xslt")

    End Sub

    Protected Sub btnSortHE_Click(sender As Object, e As EventArgs) Handles btnSortHE.Click

        xml.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("~/App_Data/XSLTHEstimadas.xslt")

    End Sub

End Class
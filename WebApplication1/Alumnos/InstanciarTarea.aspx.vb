Imports System.Data.SqlClient

Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID=opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapInstanciarTareas As New SqlDataAdapter()

    Dim bldInstanciarTareas As New SqlCommandBuilder()

    Dim dtsInstanciarTareas As New DataSet

    Dim dtblInstanciarTareas As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            submit.Enabled = False
            adapInstanciarTareas = Session("DAInstanciarTareas")
            dtsInstanciarTareas = Session("DSInstanciarTareas")
        Else
            adapInstanciarTareas = New SqlDataAdapter("SELECT * From EstudiantesTareas", conexion)
            bldInstanciarTareas = New SqlCommandBuilder(adapInstanciarTareas)
            adapInstanciarTareas.Fill(dtsInstanciarTareas, "EstudiantesTareas")
            'dtblInstanciarTareas = dtsInstanciarTareas.Tables("EstudiantesTareas")

            'txtUsuario.Text = "pepe@ikasle.ehu.es"
            txtUsuario.Text = Session("UserID")

            txtTarea.Text = Request.QueryString("codigo")
            txtHEst.Text = Request.QueryString("HEstimadas")

            Session("DAInstanciarTareas") = adapInstanciarTareas
            Session("DSInstanciarTareas") = dtsInstanciarTareas
        End If

        dtblInstanciarTareas = dtsInstanciarTareas.Tables("EstudiantesTareas")
    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        Dim nuevaRowTarea As DataRow = dtblInstanciarTareas.NewRow()
        nuevaRowTarea("Email") = txtUsuario.Text
        nuevaRowTarea("CodTarea") = txtTarea.Text
        nuevaRowTarea("HEstimadas") = txtHEst.Text
        nuevaRowTarea("HReales") = txtHReales.Text

        dtblInstanciarTareas.Rows.Add(nuevaRowTarea)

        Try
            adapInstanciarTareas.Update(dtsInstanciarTareas, "EstudiantesTareas")
        Catch ex As Exception
            Label1.Text = "Error: " & ex.Message
        End Try
        dtsInstanciarTareas.AcceptChanges()
        Label1.Text = "Tarea instanciada correctamente"
    End Sub
End Class
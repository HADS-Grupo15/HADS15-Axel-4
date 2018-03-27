Imports System.Data.SqlClient
Imports AccesoDatosSQL.accesodatosSQL

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID=opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapAsg As New SqlDataAdapter()

    Dim dtsAsg As New DataSet

    Dim dtblAsg As New DataTable

    Dim drowAsg As DataRow

    '------------------------------------'

    Dim adapTareas As New SqlDataAdapter()

    Dim dtsTareas As New DataSet

    Dim dtblTareas As New DataTable

    Dim rowTareas As DataRow

    Dim dvTareas As DataView

    Dim direccionOrden As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserID") = "pepe@ikasle.ehu.es"

        If Not Page.IsPostBack Then


            adapAsg = New SqlDataAdapter("SELECT * FROM Asignaturas INNER JOIN GruposClase ON GruposClase.codigoasig = Asignaturas.codigo 
                                          INNER JOIN EstudiantesGrupo ON EstudiantesGrupo.Grupo = GruposClase.codigo 
                                          WHERE EstudiantesGrupo.Email = '" & Session("UserID") & "'", conexion)

            'Dim bldAsignaturas As New SqlCommandBuilder(adapAsg)

            adapAsg.Fill(dtsAsg, "Asignaturas")

            dtblAsg = dtsAsg.Tables("Asignaturas")

            DropDownList1.DataSource = dtblAsg

            DropDownList1.DataValueField = "codigo"

            DropDownList1.DataBind()

            'Session("Asignaturas") = dtsAsg

            'Session("AdapterAsignaturas") = adapAsg


            '-------------------------------------------------'


            adapTareas = New SqlDataAdapter("SELECT TareasGenericas.Codigo,TareasGenericas.Descripcion,
                                             TareasGenericas.HEstimadas,TareasGenericas.TipoTarea 
                                             FROM TareasGenericas WHERE TareasGenericas.CodAsig='" & DropDownList1.SelectedItem.Value & "' 
                                             AND TareasGenericas.Explotacion='True' 
                                             AND TareasGenericas.Codigo NOT IN ( 
                                                SELECT EstudiantesTareas.CodTarea 
                                                FROM EstudiantesTareas INNER JOIN TareasGenericas ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo 
                                                WHERE EstudiantesTareas.Email='" & Session("UserID") & "' AND 
                                                TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "')", conexion)

            'Dim bldTareas As New SqlCommandBuilder(adapTareas)

            adapTareas.Fill(dtsTareas, "Tareas")

            dtblTareas = dtsTareas.Tables("Tareas")

            'dvTareas = dtsTareas.Tables(0).DefaultView

            GridViewTareas.DataSource = dtblTareas

            GridViewTareas.DataBind()

            'Session("GridViewTareas") = GridViewTareas

            'Para utilizarlo al guardar tarea instanciada en InstanciarTarea
            Session("DATareas") = adapTareas

            Session("DSTareas") = dtsTareas

        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        adapTareas = New SqlDataAdapter("SELECT TareasGenericas.Codigo,TareasGenericas.Descripcion,TareasGenericas.HEstimadas,
        TareasGenericas.TipoTarea From TareasGenericas
                                         Where TareasGenericas.CodAsig ='" & DropDownList1.SelectedValue & "' 
                                         And TareasGenericas.Explotacion ='True' 
                                         And TareasGenericas.Codigo Not IN 
                                         (SELECT EstudiantesTareas.CodTarea FROM EstudiantesTareas INNER JOIN TareasGenericas 
                                         ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo 
                                         WHERE EstudiantesTareas.Email='" & Session("UserID") & "' 
                                         AND TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "')", conexion)

        'Dim bldTareas As New SqlCommandBuilder(adapTareas)

        adapTareas.Fill(dtsTareas, "Tareas")

        dtblTareas = dtsTareas.Tables("Tareas")

        'dvTareas = dtsTareas.Tables(0).DefaultView

        GridViewTareas.DataSource = dtblTareas

        GridViewTareas.DataBind()

        'Session("GridViewTareas") = GridViewTareas

        'Para utilizarlo al guardar tarea instanciada en InstanciarTarea
        Session("DATareas") = adapTareas

        Session("DSTareas") = dtsTareas

    End Sub

    Protected Sub GridViewTareas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewTareas.SelectedIndexChanged
        Response.Redirect("./InstanciarTarea.aspx?codigo=" & GridViewTareas.SelectedRow.Cells(1).Text & "&HEstimadas=" & GridViewTareas.SelectedRow.Cells(3).Text)
    End Sub

    Private Sub GridViewTareas_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridViewTareas.Sorting
        dtsTareas = Session("DSTareas")
        dtblTareas = dtsTareas.Tables("Tareas")
        Dim vista = New DataView(dtblTareas)
        'vista.Sort = "firstname ASC, memberid"

        direccionOrden = Session("direccionOrden")
        If direccionOrden = " ASC" Then
            direccionOrden = " DESC"
        Else
            direccionOrden = " ASC"
        End If
        Session("direccionOrden") = direccionOrden

        vista.Sort = e.SortExpression & direccionOrden
        GridViewTareas.DataSource = vista
        GridViewTareas.DataBind()


    End Sub
End Class
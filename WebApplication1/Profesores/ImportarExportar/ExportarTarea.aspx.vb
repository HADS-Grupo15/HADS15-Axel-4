Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports Newtonsoft.Json

Public Class ExportarTarea
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID=opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapExport As New SqlDataAdapter()

    Dim dtsExport As New DataSet

    Dim dtblExport As New DataTable

    Dim drowExport As DataRow

    Dim dvFiltroAsignatura As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("UserID") = "blanco@ehu.es"
        If Not Page.IsPostBack Then

            adapExport = New SqlDataAdapter("SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.CodAsig, TareasGenericas.HEstimadas, TareasGenericas.Explotacion, TareasGenericas.TipoTarea From GruposClase INNER Join TareasGenericas On GruposClase.codigoasig = TareasGenericas.CodAsig INNER Join ProfesoresGrupo On GruposClase.codigo = ProfesoresGrupo.codigogrupo Where ProfesoresGrupo.email = '" & Session("UserID") & "'", conexion)

            'Dim bldExport As New SqlCommandBuilder(adapExport)

            adapExport.Fill(dtsExport, "TareasAsignaturaProfesor")

            dtblExport = dtsExport.Tables("TareasAsignaturaProfesor")
            Session("dtblExport") = dtblExport

            Dim dviewDistinct As New DataView(dtblExport)
            DropDownList1.DataSource = dviewDistinct.ToTable(True, "codAsig")

            DropDownList1.DataValueField = "codAsig"

            DropDownList1.DataBind()

            'Session("Asignaturas") = dtsAsg

            'Session("AdapterAsignaturas") = adapAsg

            '--------------------------------------Filtrar datatable por asignatura (seleccionada en DropDownList)
            dvFiltroAsignatura = New DataView(dtblExport)

            dvFiltroAsignatura.RowFilter = "codAsig='" & DropDownList1.SelectedValue & "'"
            Session("dvFiltroAsignatura") = dvFiltroAsignatura
            GridView1.DataSource = dvFiltroAsignatura
            'GridView1.Columns(2).Visible = False 'Ocultar columna de código asignatura para cuando GridView1.AutoGenerateColumns=false
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        dvFiltroAsignatura = Session("dvFiltroAsignatura")
        dvFiltroAsignatura.RowFilter = "codAsig='" & DropDownList1.SelectedValue & "'"
        GridView1.DataSource = dvFiltroAsignatura
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xd = New XmlDocument

        Dim dec = xd.CreateXmlDeclaration("1.0", "UTF-8", "yes")
        xd.AppendChild(dec)

        Dim tareas As XmlElement
        tareas = xd.CreateElement("tareas")
        tareas.SetAttribute("xmlns:has", "http://ji.ehu.es/has")
        xd.AppendChild(tareas)

        Dim xt0, xt1, xt2, xt3, xt4 As XmlText
        dvFiltroAsignatura = Session("dvFiltroAsignatura")
        Dim row As DataRow
        For Each row In dvFiltroAsignatura.ToTable.Rows

            Dim tarea As XmlElement
            Dim codigo As XmlAttribute
            Dim descripcion As XmlElement
            Dim hEstimadas As XmlElement
            Dim explotacion As XmlElement
            Dim tipoTarea As XmlElement

            tarea = xd.CreateElement("tarea")
            codigo = xd.CreateAttribute("codigo")
            descripcion = xd.CreateElement("descripcion")
            hEstimadas = xd.CreateElement("hestimadas")
            explotacion = xd.CreateElement("explotacion")
            tipoTarea = xd.CreateElement("tipotarea")

            xt0 = xd.CreateTextNode(row.Item("codigo"))
            xt1 = xd.CreateTextNode(row.Item("descripcion"))
            xt2 = xd.CreateTextNode(row.Item("hestimadas"))
            xt3 = xd.CreateTextNode(row.Item("explotacion"))
            xt4 = xd.CreateTextNode(row.Item("tipotarea"))

            codigo.AppendChild(xt0)
            descripcion.AppendChild(xt1)
            hEstimadas.AppendChild(xt2)
            explotacion.AppendChild(xt3)
            tipoTarea.AppendChild(xt4)

            tarea.Attributes.Append(codigo) 'puede utilizarse tarea.SetAttribute(String, String)
            tarea.AppendChild(descripcion)
            tarea.AppendChild(hEstimadas)
            tarea.AppendChild(explotacion)
            tarea.AppendChild(tipoTarea)

            xd.DocumentElement.AppendChild(tarea)

        Next

        Try
            xd.Save(Server.MapPath("~/App_Data_Export/" & DropDownList1.SelectedValue & ".xml"))
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

        Label2.Text = "El archivo " & DropDownList1.SelectedValue & ".xml ha sido exportado satisfactoriamente"

    End Sub

    Private Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        'para cuando GridView1.AutoGenerateColumns=true
        e.Row.Cells(2).Visible = False
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dvFiltroAsignatura = Session("dvFiltroAsignatura")
        Try
            Dim jsonString = JsonConvert.SerializeObject(dvFiltroAsignatura.ToTable, formatting:=Newtonsoft.Json.Formatting.Indented)
            File.WriteAllText(Server.MapPath("~/App_Data_Export/" & DropDownList1.SelectedValue & ".json"), jsonString)
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

        Label2.Text = "El archivo " & DropDownList1.SelectedValue & ".json ha sido exportado satisfactoriamente"

    End Sub
End Class
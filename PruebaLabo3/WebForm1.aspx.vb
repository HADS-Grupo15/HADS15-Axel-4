Imports AccesoDatosSQL.accesodatosSQL

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
        Label1.Text = result
    End Sub

    Private Sub WebForm1_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class
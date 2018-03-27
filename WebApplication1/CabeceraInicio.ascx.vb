Public Class CabeceraInicio
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblUserID.Text = Session("user")

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        'aqui tenemos que implementar el codigo de logout
        'borra el session user
        'cerrar la sesion (si hace falta hacer algo más)
        'redirecciona a login
    End Sub
End Class
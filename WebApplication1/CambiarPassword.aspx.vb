
Imports AccesoDatosSQL.accesodatosSQL

Public Class PassChange
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim numConf = myrandomize()

        If solicitudCambioPass(txtMail.Text, numConf) = 0 Then 'Si existe el mail
            enviarEmail(txtMail.Text, numConf, "Enlace para cambio de contraseña", "CambiarPassword2")
            Session("userMail") = txtMail.Text
            Response.Redirect("CambiarPassword2.aspx")
        Else 'Si no existe el mail
            Label1.Text = "No existe ningún usuario con ese email"
        End If

    End Sub

End Class
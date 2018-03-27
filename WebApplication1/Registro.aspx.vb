Imports AccesoDatosSQL.accesodatosSQL

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim numConf = myrandomize()

        Dim res = insertar(txtmail.Text, txtNom.Text, txtApe.Text, txtApe2.Text, numConf, rol.Text, txtPass.Text)

        txtConfirmar.Text = res

        enviarEmail(txtmail.Text, numConf, "Enlace para registro", "Confirmar")

        If res = "1" Then
            Response.Redirect("Confirmar.aspx")
        End If

    End Sub

End Class
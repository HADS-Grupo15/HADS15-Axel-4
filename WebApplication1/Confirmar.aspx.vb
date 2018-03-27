
Imports AccesoDatosSQL.accesodatosSQL

Public Class ConfirmAccount
    Inherits System.Web.UI.Page

    Dim mail As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then 'La página ha sido accedida mediante link
        If Request.QueryString("mbr") IsNot Nothing Then
                mail = Request.QueryString("mbr")
                txtCod.Text = Request.QueryString("numConf")
            Else 'La página ha sido accedida mediante CambiarPassword
                mail = Session("userMail")
            End If
        'End If

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        If confirmarUsuario(mail, txtCod.Text) = 1 Then
            Label1.Text = "Cuenta confirmada con éxito"
        Else
            Label1.Text = "No ha sido posible confirmar el registro del usuario"
        End If

    End Sub

End Class
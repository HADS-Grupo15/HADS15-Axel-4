
Imports AccesoDatosSQL.accesodatosSQL

Public Class PassChange2
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

        Dim res As String

        res = cambiarPass(txtCod.Text, mail, txtPass.Text)

        If res = 1 Then
            ans.Text = "Tu contraseña ha sido cambiada"
        Else
            ans.Text = "No ha sido posible cambiar tu contraseña"
        End If

    End Sub

End Class
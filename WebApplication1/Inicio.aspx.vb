
Imports System.Data.SqlClient
Imports AccesoDatosSQL.accesodatosSQL
Imports System.Security.Cryptography

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        'Comprobar si las validaciones (concretamente CustomValidator) son correctas
        'If (Page.IsValid) Then
        Dim logResult As Integer

        logResult = comprobarUsuario(txtMail.Text, txtPass.Text)

        If logResult = -1 Then
            lblAns.Text = "Ese email no se encuentra registrado"
        ElseIf logResult = 0 Then
            lblAns.Text = "Contraseña errónea"
        Else
            Session("UserID") = txtMail.Text

            'Redirigir a aplicación principal
            If tipoUsuario(txtMail.Text) = "Profesor" Then
                If txtMail.Text = "vadillo@ehu.es" Then
                    'System.Web.Security.FormsAuthentication.SetAuthCookie("Vadillo", False)
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage("Vadillo", False)
                Else
                    'System.Web.Security.FormsAuthentication.SetAuthCookie("Profesor", False)
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage("Profesor", False)

                End If
                If Request.QueryString("ReturnURL") Is Nothing Then 'Si no se viene de ninguna página de la aplicación
                    Response.Redirect("./Profesores/Profesor.aspx")
                End If
            Else 'tipo.Read Is "Alumno"
                    'System.Web.Security.FormsAuthentication.SetAuthCookie("Alumno", False)
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage("Alumno", False)
                If Request.QueryString("ReturnURL") Is Nothing Then 'Si no se viene de ninguna página de la aplicación
                    Response.Redirect("./Alumnos/Alumno.aspx")
                End If
            End If
        End If
    End Sub

End Class
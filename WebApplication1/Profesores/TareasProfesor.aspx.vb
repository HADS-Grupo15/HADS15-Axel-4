Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserID") = "blanco@ehu.es"

        Label1.Text = Session("UserID")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("./InsertarTarea.aspx")

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Response.Redirect("./Profesor.aspx")

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        Session.Abandon()

        Response.Redirect("../Inicio.aspx")

    End Sub

End Class
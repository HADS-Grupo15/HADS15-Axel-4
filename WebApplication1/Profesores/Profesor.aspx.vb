Public Class Profesor2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = Session("UserID")

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        Session.Abandon()

        Response.Redirect("../Inicio.aspx")

    End Sub

    Protected Sub LinkButton8_Click(sender As Object, e As EventArgs) Handles LinkButton8.Click

    End Sub

    Protected Sub LinkButton10_Click(sender As Object, e As EventArgs) Handles LinkButton10.Click

        Response.Redirect("./ImportarXML.aspx")

    End Sub

    Protected Sub LinkButton11_Click(sender As Object, e As EventArgs) Handles LinkButton11.Click

        Response.Redirect("./ExportarTarea.aspx")

    End Sub

End Class
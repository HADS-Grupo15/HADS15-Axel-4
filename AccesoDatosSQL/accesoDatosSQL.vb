Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class accesodatosSQL

    Private Shared conexion As New SqlConnection

    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String

        Try

            conexion.ConnectionString = "Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;User ID=opalomo001;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

            conexion.Open()

        Catch ex As Exception

            Return "ERROR DE CONEXIÓN: " + ex.Message

        End Try

        Return "CONEXION OK"

    End Function

    Public Shared Function myrandomize() As Integer

        Randomize()
        Dim NumConf As Integer = CLng(Rnd() * 9000000) + 1000000

        Return NumConf

    End Function

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellido1 As String,
                                    ByVal apellido2 As String, ByVal numconfir As Integer,
                                    ByVal tipo As String, ByVal pass As String) As String

        conectar()

        Dim apellidos As String

        apellidos = apellido1 & " " & apellido2

        Dim query = "insert into Usuarios (email,nombre,apellidos,numconfir,confirmado,tipo,pass) values (
        
        '" & email & "',
        '" & nombre & "',
        '" & apellidos & "',
        '" & numconfir & "',
        '0',
        '" & tipo & "',
        '" & pass & "'
        )"

        comando = New SqlCommand(query, conexion)

        Dim numregs = comando.ExecuteNonQuery()

        cerrarconexion()

        Return numregs

    End Function

    Public Shared Function existeUsuario(ByVal email As String) As Integer

        Dim errorConexion = conectar()

        Dim query = "select * from Usuarios where email='" & email & "' AND confirmado='" & True & "'"

        comando = New SqlCommand(query, conexion)

        If comando.ExecuteNonQuery() = 0 Then
            cerrarconexion()
            Return -1
        End If

        cerrarconexion()

        Return 0

    End Function

    Public Shared Function tipoUsuario(ByVal email) As String
        conectar()

        Dim query = "select tipo from Usuarios where email='" & email & "'"

        Dim comando = New SqlCommand(query, conexion)

        Dim tipo = comando.ExecuteReader()

        tipo.Read()

        Dim resultString = tipo.Item("tipo")

        cerrarconexion()

        Return resultString

    End Function

    Public Shared Function comprobarUsuario(ByVal email As String, ByVal password As String) As Integer

        If existeUsuario(email) = -1 Then
            Return -1
        End If

        conectar()

        Dim query = "select count(*) from Usuarios where email='" & email & "' AND pass='" & password & "'"

        comando = New SqlCommand(query, conexion)

        Dim numregs = comando.ExecuteScalar()

        cerrarconexion()

        Return numregs

    End Function

    Public Shared Function confirmarUsuario(ByVal email As String, ByVal numconf As String) As Integer

        conectar()

        Dim query = "UPDATE Usuarios SET confirmado=1 WHERE email='" & email & "' AND numconfir=" & numconf & " AND confirmado=0"

        comando = New SqlCommand(query, conexion)

        Dim numregs = comando.ExecuteNonQuery()

        cerrarconexion()

        Return numregs

    End Function

    Public Shared Function solicitudCambioPass(ByVal email, ByVal numConf) As Integer

        If existeUsuario(email) = -1 Then
            cerrarconexion()
            Return -1
        End If

        conectar()

        'ACTUALIZAR EL CODIGO DEL USUARIO EN LA BD'
        Dim query = "UPDATE Usuarios SET numConfir=" & numConf & " WHERE email='" & email & "'"
        comando = New SqlCommand(query, conexion)
        comando.ExecuteNonQuery()

        cerrarconexion()

        Return 0

    End Function

    Public Shared Function enviarEmail(ByVal email_to As String, ByVal numconf As Integer, ByVal subject As String, ByVal nombre_pagina As String) As Boolean
        Try
            'Direccion de origen
            Dim email_from As String = "opalomo001@ikasle.ehu.eus"
            Dim from_name As String = "HADS15_OscarAxel"
            Dim from_address As New MailAddress(email_from, from_name)
            'Direccion de destino
            Dim to_address As New MailAddress(email_to)
            'Password de la cuenta
            Dim from_pass As String = "Freetanga69"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = subject
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "http://localhost:60975/" & nombre_pagina & ".aspx?mbr=" & email_to & "&numconf=" & numconf & "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function cambiarPass(ByVal numconfir As String, ByVal email As String, ByVal newpass As String) As Integer

        conectar()

        Dim query = "UPDATE Usuarios SET pass='" & newpass & "' WHERE email='" & email & "' AND numconfir=" & numconfir

        comando = New SqlCommand(query, conexion)

        If comando.ExecuteNonQuery() = 0 Then
            cerrarconexion()
            Return 0
        End If

        cerrarconexion()
        Return 1

    End Function

    Public Shared Sub cerrarconexion()

        conexion.Close()

    End Sub

End Class

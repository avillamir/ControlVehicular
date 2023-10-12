Public Class Form2
    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Dim usuario As String = txtUsuario.Text
        Dim contraseña As String = txtContraseña.Text

        If usuario = "AngelVilla" AndAlso contraseña = "1234" Then
            ' Inicio de sesión exitoso
            MessageBox.Show("✅ ¡Inicio de sesión exitoso! ✨")

            ' Limpiar las celdas
            txtUsuario.Text = ""
            txtContraseña.Text = ""

            ' Mostrar el formulario siguiente (Form24) y pasar el usuario
            Dim formularioSiguiente As New SubPanel(usuario)
            formularioSiguiente.Show()

            ' Ocultar el formulario actual (Form1)
            Me.Hide()
        Else
            ' Inicio de sesión fallido
            MessageBox.Show("❌ El Usuario o Contraseña Incorrecto")

            ' Limpiar las celdas
            txtUsuario.Text = ""
            txtContraseña.Text = ""

            ' Enfocar el campo de usuario
            txtUsuario.Focus()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
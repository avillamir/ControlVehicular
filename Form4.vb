Imports System.Data.SqlClient
Public Class Form4
    Private ReadOnly connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private dataTable As DataTable
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New SqlConnection(connectionString)
        connection.Open()

        ActualizarDataGridView()
    End Sub
    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        connection.Close()
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        Dim nivelUsuario As String = txtNivel.Text.Trim()
        Dim nombre As String = txtNombre.Text.Trim()
        Dim apellidos As String = txtApellidos.Text.Trim()
        Dim cedulaUsuario As String = txtCedula.Text.Trim()
        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim claveUsuario As String = txtClaveUsuario.Text.Trim()

        ' Validar los valores ingresados
        If Not String.IsNullOrEmpty(cedulaUsuario) Then
            Try
                ' Insertar los datos utilizando el procedimiento almacenado
                command = New SqlCommand("sp_InsertaUsuario", connection) With {
                    .CommandType = CommandType.StoredProcedure
                }
                command.Parameters.AddWithValue("@Nivel", nivelUsuario)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Apellidos", apellidos)
                command.Parameters.AddWithValue("@Cedula", cedulaUsuario)
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario)
                command.Parameters.AddWithValue("@ClaveUsuario", claveUsuario)

                If command.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Datos ingresados correctamente")
                Else
                    MessageBox.Show("Ingrese valores válidos.")
                End If

                ActualizarDataGridView()

            Catch ex As Exception
                MessageBox.Show("Error al insertar los datos: " + ex.Message)
            Finally
                LimpiarTextBoxes()
            End Try
        Else
            MessageBox.Show("Ingrese valores válidos en los campos.")
        End If
    End Sub

    Private Sub ActualizarDataGridView()
        Try
            command = New SqlCommand("SELECT * FROM USUARIOS", connection)
            adapter = New SqlDataAdapter(command)
            dataTable = New DataTable()
            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable

        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos: " + ex.Message)
        End Try
    End Sub

    Private Sub LimpiarTextBoxes()
        txtNivel.Text = String.Empty
        txtNombre.Text = String.Empty
        txtApellidos.Text = String.Empty
        txtCedula.Text = String.Empty
        txtNombreUsuario.Text = String.Empty
        txtClaveUsuario.Text = String.Empty
    End Sub
End Class
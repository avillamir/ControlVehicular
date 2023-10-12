Imports System.Data.SqlClient
Public Class Form5
    Private ReadOnly connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private dataTable As DataTable
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New SqlConnection(connectionString)
        connection.Open()

        ActualizarDataGridView()
    End Sub

    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        connection.Close()
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim nivelUsuario As String = txtNivel.Text.Trim()
        Dim nombre As String = txtNombre.Text.Trim()
        Dim apellidos As String = txtApellidos.Text.Trim()
        Dim cedulaUsuario As String = txtCedula.Text.Trim()
        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim claveUsuario As String = txtClaveUsuario.Text.Trim()

        ' Validar los valores ingresados
        If Not String.IsNullOrEmpty(cedulaUsuario) Then
            Try
                ' Modificar los datos utilizando el procedimiento almacenado
                command = New SqlCommand("sp_EditaUsuario", connection) With {
                    .CommandType = CommandType.StoredProcedure
                }
                command.Parameters.AddWithValue("@Nivel", nivelUsuario)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Apellidos", apellidos)
                command.Parameters.AddWithValue("@Cedula", cedulaUsuario)
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario)
                command.Parameters.AddWithValue("@ClaveUsuario", claveUsuario)

                command.ExecuteNonQuery()

                MessageBox.Show("Datos modificados correctamente.")

                ActualizarDataGridView()

            Catch ex As Exception
                MessageBox.Show("Error al modificar los datos: " + ex.Message)
            Finally
                LimpiarTextBoxes()
            End Try
        Else
            MessageBox.Show("Ingrese valores válidos en los campos.")
        End If
    End Sub

    Private Sub ActualizarDataGridView()
        Try
            adapter = New SqlDataAdapter("SELECT * FROM USUARIOS", connection)
            dataTable = New DataTable()
            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al obtener los datos: " + ex.Message)
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Obtener el índice de la fila seleccionada
        Dim rowIndex As Integer = e.RowIndex

        ' Verificar que se haya seleccionado una fila válida
        If rowIndex >= 0 AndAlso rowIndex < DataGridView1.Rows.Count Then
            ' Obtener la fila seleccionada
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(rowIndex)

            ' Obtener los valores de las celdas de la fila seleccionada y asignarlos a los campos de texto
            txtNivel.Text = selectedRow.Cells("Nivel").Value.ToString()
            txtNombre.Text = selectedRow.Cells("Nombre").Value.ToString()
            txtApellidos.Text = selectedRow.Cells("Apellidos").Value.ToString()
            txtCedula.Text = selectedRow.Cells("Cedula").Value.ToString()
            txtNombreUsuario.Text = selectedRow.Cells("NombreUsuario").Value.ToString()
            txtClaveUsuario.Text = selectedRow.Cells("ClaveUsuario").Value.ToString()
        End If
    End Sub

End Class
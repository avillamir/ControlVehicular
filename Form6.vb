Imports System.Data.SqlClient
Public Class Form6
    Private ReadOnly connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private dataTable As DataTable
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New SqlConnection(connectionString)
        connection.Open()

        ActualizarDataGridView()
    End Sub

    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        connection.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim cedulaUsuario As String = txtCedula.Text.Trim()

        ' Validar el valor ingresado
        If Not String.IsNullOrEmpty(txtCedula.Text) Then
            ' Mostrar un mensaje de confirmación al usuario
            Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este dato?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Verificar si el usuario hizo clic en el botón "Sí"
            If confirmacion = DialogResult.Yes Then
                Try
                    ' Eliminar el dato utilizando el procedimiento almacenado
                    command = New SqlCommand("sp_EliminaUsuario", connection) With {
                    .CommandType = CommandType.StoredProcedure
                }
                    command.Parameters.AddWithValue("@Cedula", cedulaUsuario)

                    If command.ExecuteNonQuery() > 0 Then
                        MessageBox.Show("Dato eliminado correctamente")
                    Else
                        MessageBox.Show("No se encontraron resultados, ingrese una cédula válida.")
                    End If

                    ' Actualizar el DataGridView con los datos actualizados
                    ActualizarDataGridView()

                Catch ex As Exception
                    MessageBox.Show("Error al eliminar el dato: " + ex.Message)
                Finally
                    txtCedula.Text = String.Empty ' Limpiar el TextBox
                End Try
            End If
        Else
            MessageBox.Show("Ingrese una cédula.")
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Obtener el índice de la fila seleccionada
        Dim rowIndex As Integer = e.RowIndex

        ' Verificar que se haya seleccionado una fila válida
        If rowIndex >= 0 AndAlso rowIndex < DataGridView1.Rows.Count Then
            ' Obtener la fila seleccionada
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(rowIndex)

            ' Obtener los valores de las celdas de la fila seleccionada y asignarlos a los campos de texto
            txtCedula.Text = selectedRow.Cells("Cedula").Value.ToString()
        End If
    End Sub
End Class
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form10
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("server=ANGELVILLA\SQLEXPRESS; database=ControlVehiculos_dbVisual; Integrated Security = True")
        llenar_grid()
    End Sub
    Public Sub llenar_grid()
        Dim consulta As String = "select * from GestionDeConductores"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Obtener el índice de la fila seleccionada
        Dim rowIndex As Integer = e.RowIndex

        ' Verificar que se haya seleccionado una fila válida
        If rowIndex >= 0 AndAlso rowIndex < DataGridView1.Rows.Count Then
            ' Obtener la fila seleccionada
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(rowIndex)

            ' Obtener los valores de las celdas de la fila seleccionada y asignarlos a los campos de texto
            txtNumeroLicencia.Text = selectedRow.Cells("NumeroLicencia").Value.ToString()
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        ' Mostrar un mensaje de confirmación al usuario
        Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Verificar si el usuario hizo clic en el botón "Sí"
        If confirmacion = DialogResult.Yes Then
            ' Continuar con la eliminación del registro
            conexion.Open()
            Dim consulta As String = "delete from GestionDeConductores WHERE NumeroLicencia = '" & txtNumeroLicencia.Text & "' "
            comando = New SqlCommand(consulta, conexion)

            Dim cant As Integer
            cant = comando.ExecuteNonQuery()

            If cant = 1 Then
                txtNumeroLicencia.Text = ""
                MessageBox.Show("El registro se ha eliminado correctamente")

                ' Actualizar el DataGridView con los datos actualizados
                llenar_grid()
            Else
                MessageBox.Show("Ese registro no existe")
            End If
            conexion.Close()
        End If
    End Sub
End Class
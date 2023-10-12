Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form3
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private dataTable As DataTable

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'connection.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim Cedula As String = txtCedula.Text.Trim()

        If Not String.IsNullOrEmpty(Cedula) Then
            Dim connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
            Dim consulta As String = "SELECT * FROM Usuarios WHERE Cedula = @Cedula"

            Using conexion As New SqlConnection(connectionString)
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Cedula", Cedula)

                    Dim adapter As New SqlDataAdapter(comando)
                    Dim dataSet As New DataSet()

                    Try
                        conexion.Open()
                        adapter.Fill(dataSet, "Usuarios")

                        If dataSet.Tables("Usuarios").Rows.Count > 0 Then
                            DataGridView1.DataSource = dataSet.Tables("Usuarios")
                        Else
                            MessageBox.Show("No se encontraron resultados,Ingresa una Cédula válida.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar los datos: " + ex.Message)
                    Finally
                        txtCedula.Text = String.Empty ' Limpiar el TextBox
                        conexion.Close()
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Ingresa un número de Cédula válida")
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataSource = Nothing ' Limpiar el origen de datos del DataGridView
        DataGridView1.Rows.Clear() ' Limpiar las filas del DataGridView
        DataGridView1.Columns.Clear() ' Limpiar las columnas del DataGridView
    End Sub
End Class
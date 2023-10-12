Imports System.Data.SqlClient
Public Class Form11
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim placaConsulta As String = txtPlaca.Text

        If Not String.IsNullOrEmpty(placaConsulta) Then
            Dim connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
            Dim consulta As String = "SELECT * FROM GestionDeVehiculosIngreso WHERE Placa = @placa"

            Using conexion As New SqlConnection(connectionString)
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@placa", placaConsulta)

                    Dim adapter As New SqlDataAdapter(comando)
                    Dim dataSet As New DataSet()

                    Try
                        conexion.Open()
                        adapter.Fill(dataSet, "GestionDeVehiculosIngreso")

                        If dataSet.Tables("GestionDeVehiculosIngreso").Rows.Count > 0 Then
                            DataGridView1.DataSource = dataSet.Tables("GestionDeVehiculosIngreso")
                        Else
                            MessageBox.Show("No se encontraron resultados,Ingresa una Placa válida.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar los datos: " + ex.Message)
                    Finally
                        txtPlaca.Text = String.Empty ' Limpiar el TextBox
                        conexion.Close()
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Ingresa un número de Placa válida")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataSource = Nothing ' Limpiar el origen de datos del DataGridView
        DataGridView1.Rows.Clear() ' Limpiar las filas del DataGridView
        DataGridView1.Columns.Clear() ' Limpiar las columnas del DataGridView
    End Sub
End Class
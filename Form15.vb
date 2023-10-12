Imports System.Data.SqlClient
Public Class Form15
    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim NumeroAlquilerConsulta As String = txtNumeroAlquiler.Text

        If Not String.IsNullOrEmpty(NumeroAlquilerConsulta) Then
            Dim connectionString As String = "Data Source=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual;Integrated Security=True"
            Dim consulta As String = "SELECT * FROM GestionDeAlquilerVehiculos  WHERE NumeroAlquiler= @numeroalquiler"

            Using conexion As New SqlConnection(connectionString)
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@numeroalquiler", NumeroAlquilerConsulta)

                    Dim adapter As New SqlDataAdapter(comando)
                    Dim dataSet As New DataSet()

                    Try
                        conexion.Open()
                        adapter.Fill(dataSet, "GestionDeAlquilerVehiculos ")

                        If dataSet.Tables("GestionDeAlquilerVehiculos ").Rows.Count > 0 Then
                            DataGridView1.DataSource = dataSet.Tables("GestionDeAlquilerVehiculos ")
                        Else
                            MessageBox.Show("No se encontraron resultados,Ingresa un Número de Alquiler válido.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar los datos: " + ex.Message)
                    Finally
                        txtNumeroAlquiler.Text = String.Empty ' Limpiar el TextBox
                        conexion.Close()
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Ingresa un Número de Alquiler válido")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataSource = Nothing ' Limpiar el origen de datos del DataGridView
        DataGridView1.Rows.Clear() ' Limpiar las filas del DataGridView
        DataGridView1.Columns.Clear() ' Limpiar las columnas del DataGridView
    End Sub
End Class
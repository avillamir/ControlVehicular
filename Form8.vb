Imports System.Data.SqlClient

Public Class Form8
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        conexion.Open()
        Dim consulta As String = "Insert into GestionDeConductores (Nombre,ApellidoPaterno,ApellidoMaterno,TelefonoFijo,
         TelefonoMovil,CedulaConductor,NumeroLicencia,CategoriaLicencia,PlacaVehiculo,NumeroIngreso,
         FechaVencimiento)" & "values ('" & txtnombre.Text & "', '" & txtApellidoPaterno.Text & "', 
         '" & txtApellidoMaterno.Text & "', '" & txtTelefonoFijo.Text & "', '" & txtTelefonoMovil.Text & "',
         '" & txtCedulaConductor.Text & "','" & txtNumeroLicencia.Text & "', '" & txtCategoriaLicencia.Text & "', 
        '" & txtPlacaVehiculo.Text & "','" & txtNumeroIngreso.Text & "','" & fechavencimiento.Text & "')"

        DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value = txtnombre.Text
        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value = txtApellidoPaterno.Text
        DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value = txtApellidoMaterno.Text
        DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = txtTelefonoFijo.Text
        DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value = txtTelefonoMovil.Text
        DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value = txtCedulaConductor.Text
        DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value = txtNumeroLicencia.Text
        DataGridView1.Item(7, DataGridView1.CurrentRow.Index).Value = txtCategoriaLicencia.Text
        DataGridView1.Item(8, DataGridView1.CurrentRow.Index).Value = txtPlacaVehiculo.Text
        DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value = txtNumeroIngreso.Text
        DataGridView1.Item(10, DataGridView1.CurrentRow.Index).Value = fechavencimiento.Text


        txtnombre.Text = ""
        txtApellidoPaterno.Text = ""
        txtApellidoMaterno.Text = ""
        txtTelefonoFijo.Text = ""
        txtTelefonoMovil.Text = ""
        txtCedulaConductor.Text = ""
        txtNumeroLicencia.Text = ""
        txtCategoriaLicencia.Text = ""
        txtPlacaVehiculo.Text = ""
        txtNumeroIngreso.Text = ""
        fechavencimiento.Text = ""


        comando = New SqlCommand(consulta, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos se han guardado correctamente")
        llenar_grid()
        conexion.Close()

    End Sub
End Class
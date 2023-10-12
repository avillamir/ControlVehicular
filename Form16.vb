Imports System.Data.SqlClient
Public Class Form16
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("server=ANGELVILLA\SQLEXPRESS;Initial Catalog=ControlVehiculos_dbVisual; Integrated Security = True")

        llenar_grid()
    End Sub
    Public Sub llenar_grid()
        Dim consulta As String = "select * from GestionDeAlquilerVehiculos"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        conexion.Open()
        Dim consulta As String = "Insert into GestionDeAlquilerVehiculos (NumeroAlquiler,FechaInicio,FechaFin,NombreCliente,CedulA,Telefono,
        Valor,Pago,HoraSalida,HoraLlegada,PlacaVehiculo,Origen,Destino,Codigo)" &
        "values ('" & txtNumeroAlquiler.Text & "', '" & fechaInicio.Text & "', '" & fechaFinal.Text & "', 
        '" & txtNombreCliente.Text & "', '" & txtCedula.Text & "', '" & txtTelefono.Text & "',
        '" & txtvalor.Text & "', '" & txtPago.Text & "', '" & txtHoraSalida.Text & "','" & txtHoraLlegada.Text & "',
        '" & txtPlacaVehiculo.Text & "','" & txtOrigen.Text & "', '" & txtDestino.Text & "','" & txtCodigo.Text & "')"


        DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value = txtNumeroAlquiler.Text
        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value = fechaInicio.Text
        DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value = fechaFinal.Text
        DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = txtNombreCliente.Text
        DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value = txtCedula.Text
        DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value = txtTelefono.Text
        DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value = txtvalor.Text
        DataGridView1.Item(7, DataGridView1.CurrentRow.Index).Value = txtPago.Text
        DataGridView1.Item(8, DataGridView1.CurrentRow.Index).Value = txtHoraSalida.Text
        DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value = txtHoraLlegada.Text
        DataGridView1.Item(10, DataGridView1.CurrentRow.Index).Value = txtPlacaVehiculo.Text
        DataGridView1.Item(11, DataGridView1.CurrentRow.Index).Value = txtOrigen.Text
        DataGridView1.Item(12, DataGridView1.CurrentRow.Index).Value = txtDestino.Text
        DataGridView1.Item(13, DataGridView1.CurrentRow.Index).Value = txtCodigo.Text

        txtNumeroAlquiler.Text = ""
        fechaInicio.Text = ""
        fechaFinal.Text = ""
        txtNombreCliente.Text = ""
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtvalor.Text = ""
        txtPago.Text = ""
        txtHoraSalida.Text = ""
        txtHoraLlegada.Text = ""
        txtPlacaVehiculo.Text = ""
        txtOrigen.Text = ""
        txtDestino.Text = ""
        txtCodigo.Text = ""

        comando = New SqlCommand(consulta, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos se han guardado correctamente")
        llenar_grid()
        conexion.Close()

    End Sub
End Class
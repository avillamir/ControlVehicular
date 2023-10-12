Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form17
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick


        txtNumeroAlquiler.Text = DataGridView1.SelectedCells(0).Value
        Dim fechaString As String = DataGridView1.SelectedCells(1).Value.ToString()
        Dim fecha As DateTime
        If DateTime.TryParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
            fechaInicio.Text = fecha.ToString("dd/MM/yyyy")
        Else
            ' Manejo del error: La cadena de fecha no tiene el formato esperado
        End If
        'fechaInicio.Text
        fechaInicio.Text = DataGridView1.SelectedCells(1).Value
        fechaFinal.Text = DataGridView1.SelectedCells(2).Value
        txtNombreCliente.Text = DataGridView1.SelectedCells(3).Value
        txtCedula.Text = DataGridView1.SelectedCells(4).Value
        txtTelefono.Text = DataGridView1.SelectedCells(5).Value
        txtvalor.Text = DataGridView1.SelectedCells(6).Value
        txtPago.Text = DataGridView1.SelectedCells(7).Value
        txtHoraSalida.Text = DataGridView1.SelectedCells(8).Value
        txtHoraLlegada.Text = DataGridView1.SelectedCells(9).Value
        txtPlacaVehiculo.Text = DataGridView1.SelectedCells(10).Value
        txtOrigen.Text = DataGridView1.SelectedCells(11).Value
        txtDestino.Text = DataGridView1.SelectedCells(12).Value
        txtCodigo.Text = DataGridView1.SelectedCells(13).Value


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        conexion.Open()
        Dim consulta As String = "update GestionDeAlquilerVehiculos set NumeroAlquiler= '" & txtNumeroAlquiler.Text & "',
        FechaInicio='" & fechaInicio.Text & "',FechaFin='" & fechaFinal.Text & "',NombreCliente='" & txtNombreCliente.Text & "',
        CedulA='" & txtCedula.Text & "',Telefono='" & txtTelefono.Text & "',Valor='" & txtvalor.Text & "'
        ,Pago='" & txtPago.Text & "',HoraSalida= '" & txtHoraSalida.Text & "',HoraLlegada='" & txtHoraLlegada.Text & "'
        ,PlacaVehiculo='" & txtPlacaVehiculo.Text & "',Origen='" & txtOrigen.Text & "',Destino='" & txtDestino.Text & "'
        ,Codigo='" & txtCodigo.Text & "' where NumeroAlquiler= '" & txtNumeroAlquiler.Text & "' "



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

        comando = New SqlCommand(consulta, conexion)
    End Sub
End Class
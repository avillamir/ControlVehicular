Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form13
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("server=ANGELVILLA\SQLEXPRESS; database=ControlVehiculos_dbVisual; Integrated Security = True")

        llenar_grid()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        conexion.Open()
        Dim consulta As String = "update GestionDeVehiculosIngreso set Placa= '" & txtplaca.Text & "',
        NumeroIngreso='" & txtnumeroingreso.Text & "',Marca='" & txtmarca.Text & "',Modelo='" & txtmodelo.Text & "',
        Motor='" & txtmotor.Text & "',Chasis='" & txtchasis.Text & "',NumeroPasajeros='" & txtnumeropasajeros.Text & "'
        ,Soat='" & txtsoat.Text & "',Fecha1= '" & fecha1.Text & "',RevAmbiental='" & txtrevambiental.Text & "'
        ,Fecha2='" & fecha2.Text & "',TarjetaOperacion='" & txttarjoperacion.Text & "',Fecha3='" & fecha3.Text & "'
        ,Propietario='" & txtpropietario.Text & "',Cedula='" & txtcedula.Text & "',Direccion='" & txtdireccion.Text & "'
        ,TelefonoFijo='" & txttelfijo.Text & "',TelefonoMovil= '" & txttelmovil.Text & "' where Placa= '" & txtplaca.Text & "' "


        comando = New SqlCommand(consulta, conexion)

        DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value = txtnumeroingreso.Text
        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value = txtplaca.Text
        DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value = txtmarca.Text
        DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = txtmodelo.Text
        DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value = txtmotor.Text
        DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value = txtchasis.Text
        DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value = txtnumeropasajeros.Text
        DataGridView1.Item(7, DataGridView1.CurrentRow.Index).Value = txtsoat.Text
        DataGridView1.Item(8, DataGridView1.CurrentRow.Index).Value = fecha1.Text
        DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value = txtrevambiental.Text
        DataGridView1.Item(10, DataGridView1.CurrentRow.Index).Value = fecha2.Text
        DataGridView1.Item(11, DataGridView1.CurrentRow.Index).Value = txttarjoperacion.Text
        DataGridView1.Item(12, DataGridView1.CurrentRow.Index).Value = fecha3.Text
        DataGridView1.Item(13, DataGridView1.CurrentRow.Index).Value = txtpropietario.Text
        DataGridView1.Item(14, DataGridView1.CurrentRow.Index).Value = txtcedula.Text
        DataGridView1.Item(15, DataGridView1.CurrentRow.Index).Value = txtdireccion.Text
        DataGridView1.Item(16, DataGridView1.CurrentRow.Index).Value = txttelfijo.Text
        DataGridView1.Item(17, DataGridView1.CurrentRow.Index).Value = txttelmovil.Text


        txtnumeroingreso.Text = ""
        txtplaca.Text = ""
        txtmarca.Text = ""
        txtmodelo.Text = ""
        txtmotor.Text = ""
        txtchasis.Text = ""
        txtnumeropasajeros.Text = ""
        txtsoat.Text = ""
        fecha1.Text = ""
        txtrevambiental.Text = ""
        fecha2.Text = ""
        txttarjoperacion.Text = ""
        fecha3.Text = ""
        txtpropietario.Text = ""
        txtcedula.Text = ""
        txtdireccion.Text = ""
        txttelfijo.Text = ""
        txttelmovil.Text = ""

        comando = New SqlCommand(consulta, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos se han modificado correctamente")

        conexion.Close()
    End Sub
    Public Sub llenar_grid()
        Dim consulta As String = "select * from GestionDeVehiculosIngreso"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        txtnumeroingreso.Text = DataGridView1.SelectedCells(0).Value
        txtplaca.Text = DataGridView1.SelectedCells(1).Value
        txtmarca.Text = DataGridView1.SelectedCells(2).Value
        txtmodelo.Text = DataGridView1.SelectedCells(3).Value
        txtmotor.Text = DataGridView1.SelectedCells(4).Value
        txtchasis.Text = DataGridView1.SelectedCells(5).Value
        txtnumeropasajeros.Text = DataGridView1.SelectedCells(6).Value
        txtsoat.Text = DataGridView1.SelectedCells(7).Value

        Dim fechaString As String = DataGridView1.SelectedCells(8).Value.ToString()
        Dim fecha As DateTime
        If DateTime.TryParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
            fecha1.Text = fecha.ToString("dd/MM/yyyy")
        Else
            ' Manejo del error: La cadena de fecha no tiene el formato esperado
        End If
        fecha1.Text = DataGridView1.SelectedCells(8).Value
        txtrevambiental.Text = DataGridView1.SelectedCells(9).Value
        fecha2.Text = DataGridView1.SelectedCells(10).Value
        txttarjoperacion.Text = DataGridView1.SelectedCells(11).Value
        fecha3.Text = DataGridView1.SelectedCells(10).Value
        txtpropietario.Text = DataGridView1.SelectedCells(13).Value
        txtcedula.Text = DataGridView1.SelectedCells(14).Value
        txtdireccion.Text = DataGridView1.SelectedCells(15).Value
        txttelfijo.Text = DataGridView1.SelectedCells(16).Value
        txttelmovil.Text = DataGridView1.SelectedCells(17).Value


    End Sub
End Class
Imports System.Data.SqlClient
Public Class Form12
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("server=ANGELVILLA\SQLEXPRESS; database=ControlVehiculos_dbVisual; Integrated Security = True")

        llenar_grid()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        conexion.Open()
        Dim consulta As String = "Insert into GestionDeVehiculosIngreso (NumeroIngreso,Placa,Marca,Modelo,Motor,Chasis,NumeroPasajeros,Soat,Fecha1,RevAmbiental,Fecha2,TarjetaOperacion,Fecha3,Propietario,Cedula,Direccion,TelefonoFijo,TelefonoMovil)" &
        "values ('" & txtnumeroingreso.Text & "', '" & txtplaca.Text & "', '" & txtmarca.Text & "', '" & txtmodelo.Text & "', '" & txtmotor.Text & "', '" & txtchasis.Text & "','" & txtnumeropasajeros.Text & "', 
        '" & txtsoat.Text & "', '" & fecha1.Text & "','" & txtrevambiental.Text & "','" & fecha2.Text & "', '" & txttarjoperacion.Text & "','" & fecha3.Text & "','" & txtpropietario.Text & "', '" & txtcedula.Text & "','" & txtdireccion.Text & "',
        '" & txttelfijo.Text & "', '" & txttelmovil.Text & "')"

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
        MessageBox.Show("Los datos se han guardado correctamente")
        llenar_grid()
        conexion.Close()

    End Sub
    Public Sub llenar_grid()
        Dim consulta As String = "select * from GestionDeVehiculosIngreso"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form9
    Dim conexion As SqlConnection
    Dim comando As SqlCommand
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("server=ANGELVILLA\SQLEXPRESS; database=ControlVehiculos_dbVisual; Integrated Security = True")

        llenar_grid()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        conexion.Open()
        Dim consulta As String = "update GestionDeConductores set NumeroLicencia ='" & txtNumeroLicencia.Text & "',
        Nombre='" & txtnombre.Text & "',ApellidoPaterno='" & txtApellidoPaterno.Text & "',ApellidoMaterno='" & txtApellidoMaterno.Text & "',
        TelefonoFijo='" & txtTelefonoFijo.Text & "',TelefonoMovil='" & txtTelefonoMovil.Text & "',CedulaConductor='" & txtCedulaConductor.Text & "'
        ,CategoriaLicencia= '" & txtCategoriaLicencia.Text & "',PlacaVehiculo='" & txtPlacaVehiculo.Text & "'
        ,NumeroIngreso='" & txtNumeroIngreso.Text & "',
        FechaVencimiento='" & fechavencimiento.Text & "' where NumeroLicencia= '" & txtNumeroLicencia.Text & "' "


        comando = New SqlCommand(consulta, conexion)

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
        MessageBox.Show("Los datos se han modificado correctamente")
        llenar_grid()
        conexion.Close()
    End Sub
    Public Sub llenar_grid()
        Dim consulta As String = "select * from GestionDeConductores"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        txtnombre.Text = DataGridView1.SelectedCells(0).Value
        txtApellidoPaterno.Text = DataGridView1.SelectedCells(1).Value
        txtApellidoMaterno.Text = DataGridView1.SelectedCells(2).Value
        txtTelefonoFijo.Text = DataGridView1.SelectedCells(3).Value
        txtTelefonoMovil.Text = DataGridView1.SelectedCells(4).Value
        txtCedulaConductor.Text = DataGridView1.SelectedCells(5).Value
        txtNumeroLicencia.Text = DataGridView1.SelectedCells(6).Value
        txtCategoriaLicencia.Text = DataGridView1.SelectedCells(7).Value
        txtPlacaVehiculo.Text = DataGridView1.SelectedCells(8).Value
        txtNumeroIngreso.Text = DataGridView1.SelectedCells(9).Value

        Dim fechaString As String = DataGridView1.SelectedCells(10).Value.ToString()
        Dim fecha As DateTime
        If DateTime.TryParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
            fechavencimiento.Text = fecha.ToString("dd/MM/yyyy")
        Else
            ' Manejo del error: La cadena de fecha no tiene el formato esperado
        End If
        fechavencimiento.Text = DataGridView1.SelectedCells(10).Value
    End Sub
End Class
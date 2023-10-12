Imports System.Windows
Imports System.Windows.Forms.DataFormats
Imports FontAwesome.Sharp

Public Class SubPanel
    Private usuario As String
    Private currentBtn As IconFont
    Private leftborderBtn As Panel
    Private currentForms As Form

    Public Sub New(ByVal usuario As String)
        InitializeComponent()

        ' Guardar el valor del usuario en una variable del formulario
        Me.usuario = usuario
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LabelUsuario.Text = usuario
        hideSudmenu()
    End Sub

    Private Sub hideSudmenu()
        PanelSubUsuarios.Visible = False
        PanelSubUConductores.Visible = False
        PanelSubVehiculos.Visible = False
        PanelSubAlquiler.Visible = False
    End Sub

    Private Sub showSubmenu(subMenu As Panel)
        If subMenu.Visible = False Then
            hideSudmenu()
            subMenu.Visible = True
        Else
            subMenu.Visible = False
        End If
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        showSubmenu(PanelSubUsuarios)
    End Sub

    Private Sub btnConductores_Click(sender As Object, e As EventArgs) Handles btnConductores.Click
        showSubmenu(PanelSubUConductores)
    End Sub

    Private Sub btnVehiculos_Click(sender As Object, e As EventArgs) Handles btnVehiculos.Click
        showSubmenu(PanelSubVehiculos)
    End Sub

    Private Sub btnAlquiler_Click(sender As Object, e As EventArgs) Handles btnAlquiler.Click
        showSubmenu(PanelSubAlquiler)
    End Sub

    Private Sub btnAcercaDe_Click(sender As Object, e As EventArgs) Handles btnAcercaDe.Click
        openSubPanelForm(New Form19())
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        If MsgBox("¿Desea salir de la aplicación?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            End
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        hideSudmenu()
    End Sub

    Private Sub horafecha_Tick(sender As Object, e As EventArgs) Handles horafecha.Tick

        lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
        lblFecha.Text = DateTime.Now.ToShortDateString()

    End Sub

    Private Sub openSubPanelForm(subForm As Form)
        If currentForms IsNot Nothing Then currentForms.Close()
        currentForms = subForm
        subForm.TopLevel = False
        subForm.FormBorderStyle = FormBorderStyle.None
        subForm.Dock = DockStyle.Fill
        SubPanelForm.Controls.Add(subForm)
        SubPanelForm.Tag = subForm
        subForm.BringToFront()
        subForm.Show()
    End Sub
    Private Sub BtnBuscarUsuario_Click(sender As Object, e As EventArgs) Handles BtnBuscarUsuario.Click
        openSubPanelForm(New Form3())
    End Sub

    Private Sub BtnInsertarUsuario_Click(sender As Object, e As EventArgs) Handles BtnInsertarUsuario.Click
        openSubPanelForm(New Form4())
    End Sub

    Private Sub BtnModificarUsuario_Click(sender As Object, e As EventArgs) Handles BtnModificarUsuario.Click
        openSubPanelForm(New Form5())
    End Sub

    Private Sub BtnEliminarUsuario_Click(sender As Object, e As EventArgs) Handles BtnEliminarUsuario.Click
        openSubPanelForm(New Form6())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        openSubPanelForm(New Form7())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        openSubPanelForm(New Form8())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        openSubPanelForm(New Form9())
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        openSubPanelForm(New Form10())
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        openSubPanelForm(New Form11())
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        openSubPanelForm(New Form12())
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        openSubPanelForm(New Form13())
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        openSubPanelForm(New Form14())
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        openSubPanelForm(New Form15())
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        openSubPanelForm(New Form16())
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        openSubPanelForm(New Form17())
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        openSubPanelForm(New Form18())
    End Sub

    'Private Sub BtnBuscarUsuario_Click(sender As Object, e As EventArgs) Handles BtnBuscarUsuario.Click
    ' hideSudmenu()'



End Class

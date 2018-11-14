Public Class ClienteForm
    Dim IdProvincia_ As Integer
    Dim operacion_ As String
    Dim MiCliente As New ClienteClass

    Public Property IdRubro() As Integer
        Get
            Return IdProvincia_

        End Get
        Set(value As Integer)

            IdProvincia_ = value
        End Set
    End Property
    Public Property operacion() As String
        Get
            Return operacion_
        End Get
        Set(ByVal value As String)
            operacion_ = value
        End Set

    End Property

    Dim indice_ As Byte

    Public Property indice() As String
        Get
            Return indice_
        End Get
        Set(ByVal value As String)
            indice_ = value
        End Set

    End Property

    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancelar.Click

        Me.Close()

    End Sub


    Private Sub Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aceptar.Click

        If operacion_ <> "Agregar" Then


            MiCliente.Id = CInt(TextBox1.Text)

        End If

        MiCliente.Nombre = TextBox2.Text
        MiCliente.IdProvincia = ComboBox1.SelectedValue

        Select Case operacion_

            Case "Agregar"
                ClientesList.InsertarCliente(MiCliente)

            Case "Eliminar"
                'RubrosList.TraerRubros(MiRubro)
                ClientesList.EliminarCliente(MiCliente)

            Case "Modificar"

                ClientesList.ActualizarCliente(MiCliente)

        End Select

        Me.Close()

    End Sub

    Private Sub ClienteForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ComboBox1.DataSource = ProvinciasList.Traerprovincias()
        ComboBox1.DisplayMember = "Nombre"
        ComboBox1.ValueMember = "Id"
        ComboBox1.SelectedValue = IdProvincia_

    End Sub

End Class
Public Class ClienteForm
    Dim IdProvincia_ As Integer
    Dim operacion_ As String
    Dim MiCliente As New ClienteClass

    'El nombre de la propiedad debería ser IdProvincia
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
        'ComboBox1.DisplayMember = "Nombre" no existe la columna nombre en ProvinciasList
        ComboBox1.DisplayMember = "Provincia"
        ComboBox1.ValueMember = "Id"
        ComboBox1.SelectedValue = IdProvincia_

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "-" And Not e.KeyChar = "/" And Not e.KeyChar = "," And Not e.KeyChar = "." And Not e.KeyChar = ";" Then



            e.Handled = True



            Exit Sub

        End If


        Dim pos As Integer = TextBox3.SelectionStart





        If pos <> 2 And pos <> 5 And (e.KeyChar = "-" Or e.KeyChar = "/" Or e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = ";") Then





            e.Handled = True





            Exit Sub

        End If



        If Char.IsNumber(e.KeyChar) And (pos = 2 Or pos = 5) Then

            e.Handled = True
            Exit Sub

        End If


    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress


        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then



            e.Handled = True




            Exit Sub
        End If



    End Sub



End Class
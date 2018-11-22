Public Class ClientesGrid
    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click

        ClienteForm.operacion = "Agregar"
        ClienteForm.Text = "Agregar"



        ClienteForm.Show()
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click


        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No hay filas para eliminar.")
            Exit Sub
        End If

        ClienteForm.operacion = "Eliminar"
        ClienteForm.Text = "Eliminar "
        ClienteForm.indice = DataGridView1.CurrentRow.Index


        LlenarForm()
        ClienteForm.Show()
        Dim fila As Integer = DataGridView1.CurrentRow.Index

        DataGridView1.Rows.Item(fila).Selected = False
        DataGridView1.Rows.Item(fila).Selected = True




    End Sub

    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click

        'Determina si existen filas en el DataGridView
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No hay filas para modificar.")
            Exit Sub
        End If

        ClienteForm.operacion = "Modificar"
        ClienteForm.Text = "Modificar"
        ClienteForm.indice = DataGridView1.CurrentRow.Index


        LlenarForm()


        ClienteForm.Show()
        'ArticuloForm.Label.Text = "Modificar "


        Dim fila As Integer = DataGridView1.CurrentRow.Index
        'Selecciono nuevamente la fila para que refresque el contenido, sino no muestra la modificación.
        DataGridView1.Rows(DataGridView1.CurrentRow.Index).Selected = False
        DataGridView1.Rows(DataGridView1.CurrentRow.Index).Selected = True

    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click

        Me.Close()
    End Sub

    Private Sub ClientesGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ArticulosCollectionBindingSource.DataSource = ClientesList.TraerClientes
        ClientesCollectionBindingSource.DataSource = ClientesList.TraerClientes
        'Debe llenar provinciasList para que aprezca la columna nomprovincia.
        ProvinciasList.Traerprovincias()

        'Lleno el datagrid con turnosList.
        ' DataGridView1.DataSource = turnosList.TraerTurnos

        'Si la cantidad de filas es mayor a cero, entonces selecciono la primer fila.
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows(0).Selected = True
        End If



    End Sub





    Private Sub LlenarForm()

        'Número de fila seleccionado en el datagridview
        Dim fila As Integer = DataGridView1.CurrentRow.Index

        ClienteForm.TextBox1.Text = ClientesList.Item(fila).Id
        ClienteForm.TextBox2.Text = ClientesList.Item(fila).Nombre
        'ClienteForm.ComboBox1.Text = ClientesList.Item(fila).IdProvincia
        'Se pasa IdProvincia a la propiedadIdProvincia para seleccionar el item en el combo.
        ClienteForm.IdRubro = ClientesList(fila).IdProvincia


    End Sub
End Class
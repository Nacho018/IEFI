Imports System.ComponentModel
Imports System.Text


Public Class ProvinciasCollection


    Inherits BindingList(Of ProvinciaClass)

    Protected Overrides Sub OnAddingNew(ByVal e As System.ComponentModel.AddingNewEventArgs)
        MyBase.OnAddingNew(e)
        e.NewObject = New ProvinciaClass
    End Sub

    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Function FindCore(ByVal prop As PropertyDescriptor, ByVal key As Object) As Integer
        For Each provincia In Me
            If prop.GetValue(provincia).Equals(key) Then
                Return Me.IndexOf(provincia)
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' Trae todos las Articulos.
    ''' </summary>
    ''' <returns></returns>
    Public Function Traerprovincias() As ProvinciasCollection

        'Si la lista ya esta cargada la limpiamos.
        If Me.Items.Count > 0 Then Me.ClearItems()

        Dim ObjBaseDatos As New BaseDatosClass
        Dim MiDataTable As New DataTable
        Dim MiProvincia As ProvinciaClass

        ObjBaseDatos.objTabla = "Provincias"
        MiDataTable = ObjBaseDatos.TraerTodo

        For Each dr As DataRow In MiDataTable.Rows
            MiProvincia = New ProvinciaClass

            MiProvincia.Id = CInt(dr("Id"))
            'MiProvincia.Provincia = dr("Descripcion") No existe la columna Descripcion en la tabla Provincias
            MiProvincia.Provincia = dr("Provincia")
            'MiArticulo.IdRubro = CInt("IdRubro")

            Me.Add(MiProvincia)
        Next

        Return Me

    End Function

    '''' <summary>
    '''' Trae las Articulos filtrado por IdTurno.
    '''' </summary>
    '''' <param name="Id"></param>
    '''' <returns></returns>
    'Public Function Traerprovincias(ByVal IdRubro As Integer) As ArticulosCollection

    '    'Si la lista ya esta cargada la limpiamos.
    '    If Me.Items.Count > 0 Then Me.ClearItems()

    '    Dim ObjBaseDatos As New BaseDatosClass
    '    Dim MiDataTable As New DataTable
    '    Dim MiArticulo As ArticuloClass
    '    Dim filtro As String = "IdRubro = " & IdRubro

    '    ObjBaseDatos.objTabla = "Articulos"
    '    MiDataTable = ObjBaseDatos.TraerFiltrado(filtro)

    '    For Each dr As DataRow In MiDataTable.Rows
    '        MiArticulo = New ArticuloClass

    '        MiArticulo.Id = CInt(dr("Id"))
    '        MiArticulo.Descripcion = dr("Descripcion")
    '        MiArticulo.IdRubro = CInt(dr("IdRubro"))

    '        Me.Add(MiArticulo)
    '    Next

    '    Return Me

    'End Function

    Public Sub InsertarProvincia(ByVal MiProvincia As ProvinciaClass)

        Dim ObjBasedeDato As New BaseDatosClass
        'busca la tabla personas 
        ObjBasedeDato.objTabla = "Provincias"

        Dim vsql As New StringBuilder

        vsql.Append("(Provincia")
        'vsql.Append(", IdRubro)")

        vsql.Append(" VALUES ")

        vsql.Append("('" & MiProvincia.Provincia & "')")

        MiProvincia.Id = ObjBasedeDato.Insertar(vsql.ToString)

        'Evalúa el resultado del comando SQL.
        If MiProvincia.Id = 0 Then
            MsgBox("No fue posible agregar la Provincia ")
            Exit Sub
        End If

        Me.Add(MiProvincia)

    End Sub

    Public Sub EliminarProvincia(ByVal MiProvincia As ProvinciaClass)


        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Provincias"

        Dim resultado As Boolean
        resultado = objBaseDatos.Eliminar(MiProvincia.Id)

        If resultado Then

            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(MiProvincia)

            Dim myProperty As PropertyDescriptor = properties.Find("Id", False)

            Me.RemoveAt(Me.FindCore(myProperty, MiProvincia.Id))

        Else
            MessageBox.Show("No fue posible eliminar el registro.")
        End If

    End Sub


    Public Sub ActualizarProvincia(ByVal MiProvincia As ProvinciaClass)

        'Instancio el el Objeto BaseDatosClass para acceder al la base productos.
        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Provincias"

        Dim vSQL As New StringBuilder
        Dim vResultado As Boolean = False

        vSQL.Append("Provincia='" & MiProvincia.Provincia & "'")


        'Actualizo la tabla personas con el Id.
        Dim resultado As Boolean
        'El método actualizar es una función que devuelve True o False
        'Según como haya resultado la operación sobre la tabla SQL.
        resultado = objBaseDatos.Actualizar(vSQL.ToString, MiProvincia.Id)

        If Not resultado Then
            MessageBox.Show("No fue posible modificar el registro.")
            Exit Sub
        End If

        'El código a continuación sirve para localizar el ítem en la lista
        'en este caso un persona.
        ' Creates a new collection and assign it the properties for modulo.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(MiProvincia)

        'Sets an PropertyDescriptor to the specific property Id.
        Dim myProperty As PropertyDescriptor = properties.Find("Id", False)
        Me.Items.Item(Me.FindCore(myProperty, MiProvincia.Id)) = MiProvincia

    End Sub

End Class

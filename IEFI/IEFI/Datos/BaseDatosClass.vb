Option Strict On

Imports System.Data
Imports System.Data.SqlClient


Public Class BaseDatosClass

    'Inicializamos el string de la cadena de conexión.

    Dim CadenaConexion As String = "Data Source=.\SQLEXPRESS; DataBase=IEFI; User=sa; Password=carena"

    'Instaciamos un objeto SqlConnection pasando como parámetro la cadena
    Dim objConexion As New SqlConnection(CadenaConexion)

    'Nombre de la tabla.
    Dim objTabla_ As String

    ''' <summary>
    ''' Indica la tabla con la que va a trabajar la instancia.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property objTabla() As String
        Get
            Return objTabla_
        End Get

        Set(ByVal value As String)
            objTabla_ = value
        End Set
    End Property

    ''' <summary>
    ''' Trae todos los registros de la tabla.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerTodo() As DataTable

        'Comando SQL
        Dim objComando As String = "SELECT * FROM " & objTabla_

        'Declara el objeto DataAdapter
        Dim objDataAdapter As New SqlDataAdapter(objComando, objConexion)

        'Instancia un objeto DataTable
        Dim objDataTable As New DataTable

        'Abre la conexión a la base de datos.
        objConexion.Open()

        Try
            'Intenta llenar el datatable con el DataAdapter.
            objDataAdapter.Fill(objDataTable)

        Catch ex1 As InvalidOperationException
            'MessageBox.Show(ex1.Message)
            Throw New System.Exception(ex1.Message)

        Catch ex2 As SqlException
            MessageBox.Show(ex2.Message)

        Finally
            'Cierra la conexión.
            objConexion.Close()

        End Try

        Return objDataTable

    End Function


    ''' <summary>
    ''' Trae todos los registros de la tabla que cumplen con el fitro.
    ''' </summary>
    ''' <param name="filtro"></param>
    ''' <returns></returns>
    Public Function TraerFiltrado(ByVal filtro As String) As DataTable
        'Comando SQL
        Dim objComando As String = "SELECT * FROM " & objTabla_ & " WHERE " & filtro

        'Declara el objeto DataAdapter
        Dim objDataAdapter As New SqlDataAdapter(objComando, objConexion)

        'Instancia un objeto DataTable
        Dim objDataTable As New DataTable

        'Abre la conexión a la base de datos.
        objConexion.Open()

        Try
            'Intenta llenar el datatable con el DataAdapter.
            objDataAdapter.Fill(objDataTable)

        Catch ex1 As InvalidOperationException
            'MessageBox.Show(ex1.Message)
            Throw New System.Exception(ex1.Message)

        Catch ex2 As SqlException
            MessageBox.Show(ex2.Message)

        Finally
            'Cierra la conexión.
            objConexion.Close()

        End Try

        Return objDataTable

    End Function

    ''' <summary>
    ''' Inserta un registro en la tabla especificada.
    ''' </summary>
    ''' <param name="comandoSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insertar(ByVal comandoSQL As String) As Integer

        'Comando SQL
        Dim objComando As String = "INSERT INTO " & objTabla_ & " " & comandoSQL & "; SELECT SCOPE_IDENTITY()"
        Dim Id As Integer

        Using objConexion As New SqlConnection(CadenaConexion)
            Dim cmd As New SqlCommand(objComando, objConexion)

            'Abrimos la conexión a la base de datos.
            objConexion.Open()

            Try
                'Ejecutamos el comando objCommand y se obtiene la devolución
                'de un escalar que representa el Id del último registro insertado.
                Id = CInt(cmd.ExecuteScalar())

            Catch ex1 As InvalidOperationException
                MessageBox.Show(ex1.Message)

            Catch ex2 As SqlException
                MessageBox.Show(ex2.Message)

            Finally
                'Cerramos la conexión.
                objConexion.Close()

            End Try

            objConexion.Close()

        End Using

        Return Id

    End Function




    ''' <summary>
    ''' Elimina el registro de la tabla con el Id indicado.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <remarks></remarks>
    Public Function Eliminar(ByVal Id As Integer) As Boolean
        'Comando SQL
        Dim objComando As String = "DELETE FROM " & objTabla_ & " WHERE ID = @Id"
        Dim cmd As New SqlCommand(objComando, objConexion)
        Dim resultado As Boolean

        'Esto reemplaza el valor de Id en el parametro @ID
        cmd.Parameters.AddWithValue("@ID", Id)

        'Abrimos la conexión a la base de datos.
        objConexion.Open()

        Try
            'Intentamos ejecutar el comando SQL.
            cmd.ExecuteNonQuery()
            resultado = True

        Catch ex1 As InvalidOperationException
            MessageBox.Show(ex1.Message)
            resultado = False

        Catch ex2 As SqlException
            MessageBox.Show(ex2.Message)
            resultado = False

        Finally
            'Cerramos la conexión.
            objConexion.Close()

        End Try

        Eliminar = resultado

    End Function
    ''' <summary>
    ''' Actualiza el registro de la tabla con el Id indicado.
    ''' </summary>
    ''' <param name="comandosql"></param>
    ''' <param name="Id"></param>
    ''' <remarks></remarks>
    Public Function Actualizar(ByVal comandosql As String, ByVal Id As Integer) As Boolean
        'Comando SQL
        Dim objComando As String = "UPDATE " & objTabla_ & " SET " & comandosql & " WHERE ID = @ID"
        Dim cmd As New SqlCommand(objComando, objConexion)
        Dim resultado As Boolean

        'Esto reemplaza el valor de Id en el parametro @ID
        cmd.Parameters.AddWithValue("@ID", Id)

        'Abrimos la conexión a la base de datos.
        objConexion.Open()

        Try
            'Intentamos ejecutar el comando SQL.
            cmd.ExecuteNonQuery()
            resultado = True

        Catch ex1 As InvalidOperationException
            MessageBox.Show(ex1.Message)
            resultado = False

        Catch ex2 As SqlException
            MessageBox.Show(ex2.Message)
            resultado = False

        Finally
            'Cerramos la conexión.
            objConexion.Close()

        End Try

        Actualizar = resultado

    End Function





End Class
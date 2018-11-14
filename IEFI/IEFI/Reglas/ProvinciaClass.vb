Public Class ProvinciaClass


    Dim Id_ As Integer
    Dim Provincia_ As String

    Public Property Id() As Integer
        Get
            Return Id_
        End Get
        Set(ByVal value As Integer)
            Id_ = value
        End Set
    End Property
    Public Property Provincia() As String
        Get
            Return Provincia_
        End Get
        Set(ByVal value As String)
            Provincia_ = value
        End Set
    End Property


End Class

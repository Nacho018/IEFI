Public Class ClienteClass

    Dim Id_, IdProvincia_ As Integer
    Dim Nombre_ As String
    Dim Fecha_ As Date
    Dim Saldo_ As Decimal
    Public Property Id() As Integer
        Get
            Return Id_
        End Get
        Set(ByVal value As Integer)
            Id_ = value
        End Set
    End Property
    Public Property IdProvincia() As Integer
        Get
            Return IdProvincia_
        End Get
        Set(ByVal value As Integer)
            IdProvincia_ = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Nombre_
        End Get
        Set(ByVal value As String)
            Nombre_ = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return Fecha_
        End Get
        Set(ByVal value As Date)
            Fecha_ = value
        End Set
    End Property
    Public Property Saldo() As Decimal
        Get
            Return Saldo_
        End Get
        Set(ByVal value As Decimal)
            Saldo_ = value
        End Set
    End Property

    Dim nomprovincia_ As String
    Public ReadOnly Property nomprovincia As String
        Get
            For Each provin As ProvinciaClass In ProvinciasList
                If provin.Id = IdProvincia_ Then
                    nomprovincia_ = provin.Provincia
                    Exit For
                End If
            Next

            Return nomprovincia_
        End Get
    End Property

End Class

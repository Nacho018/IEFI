
Option Strict On
Option Explicit Off
Module ModuloPrincipal
    Public ProvinciasList As New ProvinciasCollection
    Public ClientesList As New ClientesCollection


    Public Sub Main()

        Application.Run(ClientesGrid)
    End Sub
End Module

Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Public Class AkumulasiKerjaController
    Inherits ApiController

    ' GET api/<controller>/5
    Public Function GetAkumulasiKerjaByID(id As Integer) As ClassAkumulasiKerja
        Dim Product As ClassAkumulasiKerja = New ClassAkumulasiKerja
        Return Product.GetAkumulasiKerjaByID(id)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class

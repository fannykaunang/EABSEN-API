Imports System.Net
Imports System.Web.Http

Public Class PegawaiController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetPegawai() As IEnumerable(Of ClassPegawai)
        Dim Pegawai As ClassPegawai = New ClassPegawai
        Return Pegawai.GetPegawai()
    End Function

    ' GET api/<controller>/5
    Public Function GetPegawaiByID(id As Integer) As ClassPegawai
        Dim Product As ClassPegawai = New ClassPegawai
        Return Product.GetPegawaiByID(id)
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

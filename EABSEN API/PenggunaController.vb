Imports System.Web.Http
<Route("api/pengguna/{user}/{pass}")>
Public Class PenggunaController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetPengguna() As IEnumerable(Of ClassPengguna)
        Dim Pegawai As ClassPengguna = New ClassPengguna
        Return Pegawai.GetPengguna()
    End Function

    ' GET api/<controller>/5
    Public Function GetPenggunaByID(user As String, pass As String) As ClassPengguna
        Dim Product As ClassPengguna = New ClassPengguna
        Return Product.GetPenggunaByID(user, pass)
    End Function
End Class

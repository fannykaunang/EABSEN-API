Imports System.Web.Http

Public Class SKPDController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetSKPD() As IEnumerable(Of ClassSKPD)
        Dim Pegawai As ClassSKPD = New ClassSKPD
        Return Pegawai.GetSKPD()
    End Function

    ' GET api/<controller>/5
    Public Function GetSKPDByID(id As Integer) As ClassSKPD
        Dim Product As ClassSKPD = New ClassSKPD
        Return Product.GetSKPDByID(id)
    End Function
End Class

Imports System.Net
Imports System.Web.Http

Public Class CountCheckInTodayController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetCountCheckInToday() As IEnumerable(Of ClassCountCheckInToday)
        Dim Pegawai As ClassCountCheckInToday = New ClassCountCheckInToday
        Return Pegawai.GetCountCheckInToday()
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
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

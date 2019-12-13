Imports System.Data.SqlClient
'perbaiki ini
Public Class ClassCheckInToday
    Public Property CHECKIN_COUNT As Integer
    Public Property CHECKOUT_COUNT As Integer
    Public Property TANPA_KET As Integer
    Public Property SAKIT As Integer
    Public Property DINAS As Integer
    Public Property CUTI_IJIN As Integer
    Public Property JUM_PEGAWAI As Integer

    Public Sub New()
    End Sub
    Public Sub New(CHECKIN_COUNT As Integer, ByVal CHECKOUT_COUNT As Integer, TANPA_KET As String, SAKIT As String, DINAS As String, CUTI_IJIN As String, JUM_PEGAWAI As String)
        Me.CHECKIN_COUNT = CHECKIN_COUNT
        Me.CHECKOUT_COUNT = CHECKOUT_COUNT
        Me.TANPA_KET = TANPA_KET
        Me.SAKIT = SAKIT
        Me.DINAS = DINAS
        Me.CUTI_IJIN = CUTI_IJIN
        Me.JUM_PEGAWAI = JUM_PEGAWAI
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassCountCheckInToday) = New List(Of ClassCountCheckInToday)
        If reader.HasRows Then
            While reader.Read()
                products.Add(New ClassCountCheckInToday(
                             If(IsDBNull(reader.Item("CHECKIN_COUNT")), Nothing, reader.Item("CHECKIN_COUNT")),
                             If(IsDBNull(reader.Item("CHECKOUT_COUNT")), Nothing, reader.Item("CHECKOUT_COUNT")),
                             If(IsDBNull(reader.Item("TANPA_KET")), Nothing, reader.Item("TANPA_KET")),
                             If(IsDBNull(reader.Item("SAKIT")), Nothing, reader.Item("SAKIT")),
                             If(IsDBNull(reader.Item("DINAS")), Nothing, reader.Item("DINAS")),
                             If(IsDBNull(reader.Item("CUTI_IJIN")), Nothing, reader.Item("CUTI_IJIN")),
                             If(IsDBNull(reader.Item("JUM_PEGAWAI")), Nothing, reader.Item("JUM_PEGAWAI"))))
            End While
        End If
        Return products
    End Function

    Public Function GetCountCheckInTodayByDate() As IEnumerable(Of ClassCountCheckInToday)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM [VW_CHECKIN] WHERE (CONVERT(VARCHAR(10), CHECKIN, 102) = CONVERT(VARCHAR(10), GETDATE(), 102)) ORDER BY CHECKIN", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassCountCheckInToday) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function
End Class

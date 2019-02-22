Imports System.Data.SqlClient

Public Class ClassCountCheckInToday
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
        Me.JUM_PEGAWAI = JUM_PEGAWAI
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassCountCheckInToday) = New List(Of ClassCountCheckInToday)
        If reader.HasRows Then
            While reader.Read()
                products.Add(New ClassCountCheckInToday(If(IsDBNull(reader.Item("CHECKIN_COUNT")), Nothing, reader.Item("CHECKIN_COUNT")),
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

    Public Function GetCountCheckInToday() As IEnumerable(Of ClassCountCheckInToday)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT SUM(CHECKIN_COUNT) CHECKIN_COUNT, SUM(CHECKOUT_COUNT) CHECKOUT_COUNT, SUM(TANPA_KET) TANPA_KET, SUM(SAKIT) SAKIT, SUM(DINAS) DINAS, SUM(CUTI_IJIN) CUTI_IJIN, SUM(JUM_PEGAWAI) JUM_PEGAWAI FROM [VW_REKAP_ABSEN_PERSKPD_PERHARI]", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassCountCheckInToday) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function

    'Public Function GetCountCheckInToday() As ClassCountCheckInToday
    '    Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
    '    Dim cmd As New SqlCommand("SELECT PERHARI FROM [VW_CHECKIN_GROUPBY_HARI] WHERE CHECKIN = CONVERT(VARCHAR, GETDATE(), 111)", cn)
    '    cmd.CommandType = CommandType.Text
    '    cn.Open()
    '    Dim reader As SqlDataReader = cmd.ExecuteReader()
    '    Dim products As List(Of ClassCountCheckInToday) = ConvertReader(reader)
    '    cn.Close()
    '    Return products.Find(Function(p) p.PERHARI = ID)
    'End Function
End Class

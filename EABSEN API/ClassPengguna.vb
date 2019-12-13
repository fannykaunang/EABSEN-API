Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class ClassPengguna
    Public Property success As Integer
    Public Property message As String
    Public Property USERID As Integer
    'Public Property NAMA_PEGAWAI As String
    Public Property NAMA_USER As String
    'Public Property EMAIL As String
    Public Property SANDI As String
    'Public Property IMEI As String

    Public Sub New()
    End Sub
    'Public Sub New(success As Integer, message As String, ByVal USERID As Integer, ByVal NAMA_PEGAWAI As String, ByVal NAMA_USER As String,
    '               ByVal EMAIL As String, ByVal SANDI As String, IMEI As String)
    Public Sub New(success As Integer, message As String, ByVal USERID As Integer, ByVal NAMA_USER As String, ByVal SANDI As String)
        If Not success = 1 Then
            success = 0
            message = "Login gagal"
            USERID = 0
            'Me.NAMA_PEGAWAI = NAMA_PEGAWAI
            NAMA_USER = 0
            'Me.EMAIL = EMAIL
            SANDI = 0
            'Me.IMEI = IMEI
        Else
            Me.success = success
            Me.message = message
            Me.USERID = USERID
            'Me.NAMA_PEGAWAI = NAMA_PEGAWAI
            Me.NAMA_USER = NAMA_USER
            'Me.EMAIL = EMAIL
            Me.SANDI = SANDI
            'Me.IMEI = IMEI
        End If

    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassPengguna) = New List(Of ClassPengguna)

        If reader.HasRows Then
            If reader.Read() Then
                products.Add(New ClassPengguna(1, "Login Berhasil", If(IsDBNull(reader.Item("USERID")), 0, reader.Item("USERID")),
If(IsDBNull(reader.Item("NAMA_USER")), "NN", reader.Item("NAMA_USER")),
If(IsDBNull(reader.Item("SANDI")), "NN", reader.Item("SANDI"))))
            End If
        End If

        Return products
    End Function

    Public Function GetPengguna() As IEnumerable(Of ClassPengguna)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_USER", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassPengguna) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function

    Public Function GetPenggunaByID(NAMA_USER As String, SANDI As String) As ClassPengguna
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_USER WHERE NAMA_USER = @NAMA_USER AND SANDI = @SANDI", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@NAMA_USER", NAMA_USER)
        cmd.Parameters.AddWithValue("@SANDI", SANDI)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassPengguna) = ConvertReader(reader)

        cn.Close()
        Return products.Find(Function(p) p.NAMA_USER = NAMA_USER And p.SANDI = SANDI)
    End Function
End Class
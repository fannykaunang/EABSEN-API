Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class ClassPegawai
    Public Property USERID As Integer
    Public Property NAMA_PEGAWAI As String
    Public Property TEMPAT_LAHIR As String
    Public Property TGL_LAHIR As Date
    Public Property FOTO_FILEPATH As String
    Public Property NAMA_SKPD As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal USERID As Integer, ByVal NAMA_PEGAWAI As String, ByVal TEMPAT_LAHIR As String,
                   ByVal TGL_LAHIR As Date, ByVal FOTO_FILEPATH As String, NAMA_SKPD As String)
        Me.USERID = USERID
        Me.NAMA_PEGAWAI = NAMA_PEGAWAI & " (" & USERID & ") "
        Me.TEMPAT_LAHIR = TEMPAT_LAHIR
        Me.TGL_LAHIR = TGL_LAHIR
        Me.FOTO_FILEPATH = FOTO_FILEPATH
        Me.NAMA_SKPD = NAMA_SKPD
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassPegawai) = New List(Of ClassPegawai)
        Dim list As New List(Of String)
        If reader.HasRows Then
            While reader.Read()
                products.Add(New ClassPegawai(If(IsDBNull(reader.Item("USERID")), Nothing, reader.Item("USERID")),
                                     If(IsDBNull(reader.Item("NAMA_PEGAWAI")), Nothing, reader.Item("NAMA_PEGAWAI")),
                                     If(IsDBNull(reader.Item("TEMPAT_LAHIR")), Nothing, reader.Item("TEMPAT_LAHIR")),
                                     If(IsDBNull(reader.Item("TGL_LAHIR")), Nothing, reader.Item("TGL_LAHIR")),
                                     If(IsDBNull(reader.Item("FOTO_FILEPATH")), Nothing, reader.Item("FOTO_FILEPATH")),
                                     If(IsDBNull(reader.Item("NAMA_SKPD")), Nothing, reader.Item("NAMA_SKPD"))))
            End While
        End If

        Return products
    End Function

    Public Function GetPegawai() As IEnumerable(Of ClassPegawai)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_PEGAWAI", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassPegawai) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function

    Public Function GetPegawaiByID(id As Integer) As ClassPegawai
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_PEGAWAI WHERE USERID = @USERID", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@USERID", id)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassPegawai) = ConvertReader(reader)
        cn.Close()
        Return products.Find(Function(p) p.USERID = id)
    End Function
End Class
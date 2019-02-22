Imports System.Data.SqlClient

Public Class ClassPegawaiDetail
    Public Property SKPDID As Integer
    Public Property USERID As Integer
    Public Property NIP As String
    Public Property NAMA_PEGAWAI As String
    Public Property FOTO_FILEPATH As String

    Public Sub New()
    End Sub
    Public Sub New(skpdid As Integer, ByVal userid As Integer, nip As String, nama_pegawai As String, foto_filepath As String)
        Me.SKPDID = skpdid
        Me.USERID = userid
        Me.NIP = nip
        Me.NAMA_PEGAWAI = nama_pegawai
        Me.FOTO_FILEPATH = foto_filepath
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassPegawaiDetail) = New List(Of ClassPegawaiDetail)
        If reader.HasRows Then
            While reader.Read()
                products.Add(New ClassPegawaiDetail(If(IsDBNull(reader.Item("SKPDID")), Nothing, reader.Item("SKPDID")),
                                     If(IsDBNull(reader.Item("USERID")), Nothing, reader.Item("USERID")),
                                     If(IsDBNull(reader.Item("NIP")), Nothing, reader.Item("NIP")),
                                     If(IsDBNull(reader.Item("NAMA_PEGAWAI")), Nothing, reader.Item("NAMA_PEGAWAI")),
                                     If(IsDBNull(reader.Item("FOTO_FILEPATH")), Nothing, reader.Item("FOTO_FILEPATH"))))
            End While
        End If
        Return products
    End Function

    Public Function GetDetailPegawai(ID As Integer) As ClassPegawaiDetail
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_PEGAWAI WHERE SKPDID = @SKPDID", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@SKPDID", ID)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassPegawaiDetail) = ConvertReader(reader)
        cn.Close()
        Return products.Find(Function(p) p.SKPDID = ID)
    End Function

    'Public Function GetSKPDByID(id As Integer) As ClassSKPD
    '    Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
    '    Dim cmd As New SqlCommand("SELECT * FROM VW_PEGAWAI", cn)
    '    cmd.CommandType = CommandType.Text
    '    cn.Open()
    '    Dim reader As SqlDataReader = cmd.ExecuteReader()
    '    Dim products As List(Of ClassSKPD) = ConvertReader(reader)
    '    cn.Close()
    '    Return products.Find(Function(p) p.SKPDID = id)
    'End Function
End Class

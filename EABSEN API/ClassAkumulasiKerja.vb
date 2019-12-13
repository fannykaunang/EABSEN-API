Imports System.Data.SqlClient

Public Class ClassAkumulasiKerja
    Public Property USERID As Integer
    Public Property JAM_KERJA As Integer

    Public Sub New()
    End Sub
    Public Sub New(USERID As Integer, ByVal JAM_KERJA As Integer)
        Me.USERID = USERID
        Me.JAM_KERJA = JAM_KERJA
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassAkumulasiKerja) = New List(Of ClassAkumulasiKerja)
        If reader.HasRows Then 'kasihlengkap kayak pegawai
            While reader.Read()
                products.Add(New ClassAkumulasiKerja(
                             If(IsDBNull(reader.Item("USERID")), Nothing, reader.Item("USERID")),
                             If(IsDBNull(reader.Item("JAM_KERJA")), Nothing, reader.Item("JAM_KERJA"))))
            End While
        End If
        Return products
    End Function

    Public Function GetAkumulasiKerjaByID(id As Integer) As ClassAkumulasiKerja
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT MAX(USERID) USERID, SUM(JAM_KERJA) JAM_KERJA FROM VW_AKUMULASI_JAM_KERJA WHERE USERID=@USERID AND (MONTH(CHECKIN) = MONTH(DATEADD(DD, - 1, GETDATE()))) AND (YEAR(CHECKIN) = YEAR(DATEADD(DD, - 1, GETDATE())))", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@USERID", id)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassAkumulasiKerja) = ConvertReader(reader)
        cn.Close()
        Return products.Find(Function(p) p.USERID = id)
    End Function
End Class

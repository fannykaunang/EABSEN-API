Imports System.Data.SqlClient

Public Class ClassSKPD
    Public Property SKPDID As Integer
    Public Property NAMA_SKPD As String
    Public Property Pegawai As List(Of ClassPegawai)

    Public Sub New()
    End Sub
    Public Sub New(ByVal SKPDID As Integer, ByVal NAMA_SKPD As String, pegawai As List(Of ClassPegawai))
        Me.SKPDID = SKPDID
        Me.NAMA_SKPD = NAMA_SKPD
        Me.Pegawai = pegawai
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassSKPD) = New List(Of ClassSKPD)
        '        If reader.HasRows Then
        '            While reader.Read()
        '                products.Add(New ClassSKPD(If(IsDBNull(reader.Item("SKPDID")), Nothing, reader.Item("SKPDID")),
        '                                     If(IsDBNull(reader.Item("NAMA_SKPD")), Nothing, reader.Item("NAMA_SKPD")),
        'If(IsDBNull(reader.Item("USERID")), Nothing, reader.Item("USERID"))))
        '            End While
        '        End If

        Dim dt As DataTable = GetData("SELECT * From VW_PEGAWAI")
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim customer As ClassSKPD = New ClassSKPD With {.SKPDID = Convert.ToInt32(If(IsDBNull(dt.Rows(i)("SKPDID")), Nothing, dt.Rows(i)("SKPDID"))),
                .NAMA_SKPD = If(IsDBNull(dt.Rows(i)("NAMA_SKPD")), Nothing, dt.Rows(i)("NAMA_SKPD")),
                .Pegawai = GetOrders(If(IsDBNull(dt.Rows(i)("SKPDID")), Nothing, dt.Rows(i)("SKPDID")))}
            products.Add(customer)
        Next
        Return products
    End Function

    Public Function GetOrders(ByVal customerId As String) As List(Of ClassPegawai)
        Dim orders As List(Of ClassPegawai) = New List(Of ClassPegawai)()
        Dim dt As DataTable = GetData(String.Format("SELECT * FROM VW_PEGAWAI Where SKPDID ='{0}'", customerId))
        For i As Integer = 0 To dt.Rows.Count - 1
            orders.Add(New ClassPegawai With {.USERID = Convert.ToInt32(If(IsDBNull(dt.Rows(i)("USERID")), Nothing, dt.Rows(i)("USERID"))),
                       .NAMA_PEGAWAI = If(IsDBNull(dt.Rows(i)("NAMA_PEGAWAI")), Nothing, dt.Rows(i)("NAMA_PEGAWAI")),
                       .TEMPAT_LAHIR = If(IsDBNull(dt.Rows(i)("TEMPAT_LAHIR")), Nothing, dt.Rows(i)("TEMPAT_LAHIR")),
                       .FOTO_FILEPATH = If(IsDBNull(dt.Rows(i)("FOTO_FILEPATH")), Nothing, dt.Rows(i)("FOTO_FILEPATH")),
                       .TGL_LAHIR = Convert.ToDateTime(If(IsDBNull(dt.Rows(i)("TGL_LAHIR")), Nothing, dt.Rows(i)("TGL_LAHIR"))).ToShortDateString()})
        Next

        Return orders
    End Function

    Public Function GetSKPD() As IEnumerable(Of ClassSKPD)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT TOP 100 * FROM VW_PEGAWAI", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassSKPD) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function

    Public Function GetSKPDByID(id As Integer) As ClassSKPD
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_PEGAWAI WHERE SKPDID = @SKPDID", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@SKPDID", id)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassSKPD) = ConvertReader(reader)
        cn.Close()
        Return products.Find(Function(p) p.SKPDID = id)
    End Function

    Private Function GetData(ByVal query As String) As DataTable
        Dim conString As String = ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand(query)
        Using con As SqlConnection = New SqlConnection(conString)
            Using sda As SqlDataAdapter = New SqlDataAdapter()
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    Return dt
                End Using
            End Using
        End Using
    End Function
End Class

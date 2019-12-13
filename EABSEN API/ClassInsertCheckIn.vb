Imports System.Data.SqlClient
Imports System.Globalization

Public Class ClassInsertCheckIn
    Public Property USERID As Integer
    Public Property CHECKIN As String
    Public Property CHECKTYPE As String
    Public Property PERIOD As Date
    Public Property DAY As String
    Public Property MACHINENUMBER As String
    Public Property DESCRIPTION As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal USERID As Integer, ByVal CHECKIN As Date, ByVal CHECKTYPE As String,
                   ByVal PERIOD As Date, ByVal DAY As String, MACHINENUMBER As String, DESCRIPTION As String)
        Me.USERID = USERID
        Me.CHECKIN = CHECKIN
        Me.CHECKTYPE = CHECKTYPE
        Me.PERIOD = PERIOD
        Me.DAY = DAY
        Me.MACHINENUMBER = MACHINENUMBER
        Me.DESCRIPTION = DESCRIPTION
    End Sub

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim products As List(Of ClassInsertCheckIn) = New List(Of ClassInsertCheckIn)
        Dim list As New List(Of String)
        If reader.HasRows Then
            While reader.Read()
                products.Add(New ClassInsertCheckIn(If(IsDBNull(reader.Item("USERID")), Nothing, reader.Item("USERID")),
                                     If(IsDBNull(reader.Item("CHECKIN")), Nothing, reader.Item("CHECKIN")),
                                     If(IsDBNull(reader.Item("CHECKTYPE")), Nothing, reader.Item("CHECKTYPE")),
                                     If(IsDBNull(reader.Item("PERIOD")), Nothing, reader.Item("PERIOD")),
                                     If(IsDBNull(reader.Item("DAY")), Nothing, reader.Item("DAY")),
                                     If(IsDBNull(reader.Item("MACHINENUMBER")), Nothing, reader.Item("MACHINENUMBER")),
                                     If(IsDBNull(reader.Item("DESCRIPTION")), Nothing, reader.Item("DESCRIPTION"))))
            End While
        End If

        Return products
    End Function

    Public Function Add(ByVal item As ClassInsertCheckIn) As ClassInsertCheckIn
        Dim query As String = "[dbo].[SP_INSERT_CHECKIN]" ', item.USERID, item.CHECKIN, item.CHECKTYPE, item.PERIOD, item.DAY, item.MACHINENUMBER, item.DESCRIPTION)

        Dim myCulture As CultureInfo = CultureInfo.CurrentCulture
        Dim dayOfWeek As DayOfWeek = myCulture.Calendar.GetDayOfWeek(Date.Today)
        Dim dayName As String = myCulture.DateTimeFormat.GetDayName(dayOfWeek)

        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)

            Using cmd As SqlCommand = New SqlCommand(query, con)
                con.Open()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@USERID", item.USERID)
                cmd.Parameters.AddWithValue("@CHECKIN", item.CHECKIN)
                cmd.Parameters.AddWithValue("@CHECKTYPE", "AD_emu")
                cmd.Parameters.AddWithValue("@PERIOD", DateTime.Now.ToString("MMMM") & ", " & Date.Now.Year)
                cmd.Parameters.AddWithValue("@DAY", dayName)
                cmd.Parameters.AddWithValue("@MACHINENUMBER", "66595018220064")
                cmd.Parameters.AddWithValue("@DESCRIPTION", "Absen Datang Android")
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        Return item
    End Function

    Public Function GetCheckIn() As IEnumerable(Of ClassInsertCheckIn)
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_CHECKIN", cn)
        cmd.CommandType = CommandType.Text
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassInsertCheckIn) = ConvertReader(reader)
        cn.Close()
        Return products
    End Function

    Public Function GetCheckInByID(id As Integer) As ClassInsertCheckIn
        Dim cn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM VW_CHECKIN WHERE USERID = @USERID", cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@USERID", id)
        cn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim products As List(Of ClassInsertCheckIn) = ConvertReader(reader)
        cn.Close()
        Return products.Find(Function(p) p.USERID = id)
    End Function
End Class

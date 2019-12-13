Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http

Public Class PegawaiController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetPegawai() As IEnumerable(Of ClassPegawai)
        Dim Pegawai As ClassPegawai = New ClassPegawai
        Return Pegawai.GetPegawai()
    End Function

    ' GET api/<controller>/5
    Public Function GetPegawaiByID(id As Integer) As ClassPegawai
        Dim Product As ClassPegawai = New ClassPegawai
        Return Product.GetPegawaiByID(id)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)
        Using connection = New SqlConnection(ConfigurationManager.ConnectionStrings("EABSEN_API.My.MySettings.ConnString").ConnectionString)
            'Await connection.OpenAsync()
            Dim sqlStatement = "
    INSERT INTO Aircraft 
    (Manufacturer
    ,Model
    ,RegistrationNumber
    ,FirstClassCapacity
    ,RegularClassCapacity
    ,CrewCapacity
    ,ManufactureDate
    ,NumberOfEngines
    ,EmptyWeight
    ,MaxTakeoffWeight)
    VALUES (@Manufacturer
    ,@Model
    ,@RegistrationNumber
    ,@FirstClassCapacity
    ,@RegularClassCapacity
    ,@CrewCapacity
    ,@ManufactureDate
    ,@NumberOfEngines
    ,@EmptyWeight
    ,@MaxTakeoffWeight)"
            'Await connection.ExecuteAsync(sqlStatement, model)
        End Using
    End Sub
    '    Public Async Function Post(
    '<FromBody> ByVal model As Aircraft) As Task(Of IActionResult)
    '        Using connection = New SqlConnection(_connectionString)
    '            Await connection.OpenAsync()
    '            Dim sqlStatement = "
    '    INSERT INTO Aircraft 
    '    (Manufacturer
    '    ,Model
    '    ,RegistrationNumber
    '    ,FirstClassCapacity
    '    ,RegularClassCapacity
    '    ,CrewCapacity
    '    ,ManufactureDate
    '    ,NumberOfEngines
    '    ,EmptyWeight
    '    ,MaxTakeoffWeight)
    '    VALUES (@Manufacturer
    '    ,@Model
    '    ,@RegistrationNumber
    '    ,@FirstClassCapacity
    '    ,@RegularClassCapacity
    '    ,@CrewCapacity
    '    ,@ManufactureDate
    '    ,@NumberOfEngines
    '    ,@EmptyWeight
    '    ,@MaxTakeoffWeight)"
    '            Await connection.ExecuteAsync(sqlStatement, model)
    '        End Using

    '        Return Ok()
    '    End Function

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class

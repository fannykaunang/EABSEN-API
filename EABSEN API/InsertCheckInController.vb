Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Public Class InsertCheckInController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() {"value1", "value2"}
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    'Public Function POST(<FromUri()> ByVal customer As ClassInsertCheckIn) As HttpResponseMessage
    '    '  Dim InsertCheckIn As ClassInsertCheckIn = New ClassInsertCheckIn
    '    customer.Add(customer)
    '    Dim response = Request.CreateResponse(HttpStatusCode.Created, customer)
    '    Dim uri As String = Url.Link("InsertApi", New With {customer.USERID
    '})
    '    response.Headers.Location = New Uri(uri)
    '    Return response
    'End Function

    Public Function PostInsertCheckIn(
<FromUri> ByVal customer As ClassInsertCheckIn) As HttpResponseMessage
        customer.Add(customer)
        Dim response = Request.CreateResponse(HttpStatusCode.Created, customer)
        Dim uri As String = Url.Link("DefaultApi", New With {customer.USERID
    })
        response.Headers.Location = New Uri(uri)
        Return response
    End Function

    'Public Function POST(ByVal customer As ClassInsertCheckIn) As HttpResponseMessage
    '    'customer = repository.Add(customer)

    '    Dim InsertCheckIn As ClassInsertCheckIn = New ClassInsertCheckIn
    '    InsertCheckIn.Add(customer)
    '    Dim response = Request.CreateResponse(Of ClassInsertCheckIn)(HttpStatusCode.Created, customer)
    '    Dim uri As String = Url.Link("DefaultApi", New With {customer.USERID
    '})
    '    response.Headers.Location = New Uri(uri)
    '    Return response
    'End Function

    'Class SurroundingClass
    '    Shared ReadOnly repository As ICustomerRepository = New CustomerRepository()

    '    Public Function PostCustomer(ByVal customer As Pegawai) As HttpResponseMessage
    '        customer = repository.Add(customer)
    '        Dim response = Request.CreateResponse(Of Pegawai)(HttpStatusCode.Created, customer)
    '        Dim uri As String = Url.Link("DefaultApi", New With {Key
    '        .customerID = customer.CustomerID
    '    })
    '    response.Headers.Location = New Uri(uri)
    '        Return response
    '    End Function
    'End Class

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class

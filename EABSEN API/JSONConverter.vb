Imports System.Runtime.CompilerServices
Imports System.Web.Script.Serialization

Module JSONConverter
    <Extension()>
    Function toJSON(ByVal obj As Object) As String
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        Return serializer.Serialize(obj)
    End Function

    <Extension()>
    Function toJSON(ByVal obj As Object, ByVal recursionDepth As Integer) As String
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.RecursionLimit = recursionDepth
        Return serializer.Serialize(obj)
    End Function
End Module


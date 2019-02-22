Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Newtonsoft.Json

<JsonObject(Title:="result")>
Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("application/json"))

        For Each formatter In config.Formatters
            Trace.WriteLine(formatter.[GetType]().Name)
            Trace.WriteLine(vbTab & "CanReadType: " & formatter.CanReadType(GetType(ClassPegawai)))
            Trace.WriteLine(vbTab & "CanWriteType: " & formatter.CanWriteType(GetType(ClassPegawai)))
            Trace.WriteLine(vbTab & "Base: " & formatter.[GetType]().BaseType.Name)
            Trace.WriteLine(vbTab & "Media Types: " & String.Join(", ", formatter.SupportedMediaTypes))
        Next
    End Sub

End Module

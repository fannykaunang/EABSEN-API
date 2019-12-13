Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Collections.Specialized
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports System.Web.Http.Routing
Imports Newtonsoft.Json

<JsonObject(Title:="result")>
Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/id/{action}",
            defaults:=New With {.id = RouteParameter.Optional, .action = "GET"}
        )
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("application/pdf"))

        'config.Routes.MapHttpRoute(
        '   name:="Api_Post",
        '   routeTemplate:="api/{controller}/{id}/{action}",
        '   defaults:=New With {.id = RouteParameter.Optional, .action = "Post"},
        '   constraints:=New With {.httpMethod = New HttpMethodConstraint("POST")}
        ');

        For Each formatter In config.Formatters
            Trace.WriteLine(formatter.[GetType]().Name)
            Trace.WriteLine(vbTab & "CanReadType: " & formatter.CanReadType(GetType(ClassPengguna)))
            Trace.WriteLine(vbTab & "CanWriteType: " & formatter.CanWriteType(GetType(ClassPengguna)))
            Trace.WriteLine(vbTab & "Base: " & formatter.[GetType]().BaseType.Name)
            Trace.WriteLine(vbTab & "Media Types: " & String.Join(", ", formatter.SupportedMediaTypes))
        Next
    End Sub

End Module

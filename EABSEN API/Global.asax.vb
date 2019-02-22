Imports System.Net.Http.Headers
Imports System.Web.Http
Imports System.Web.Routing

Public Class WebApiApplication
    Inherits HttpApplication
    'tes
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim config As New HttpConfiguration
        RouteTable.Routes.MapHttpRoute(name:="DefaultApi",
                                       routeTemplate:="api/{controller}/{id}",
                                       defaults:=New With {.id = RouteParameter.Optional})
        GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()
    End Sub
End Class
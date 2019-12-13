Imports System.Net.Http.Headers
Imports System.Web.Http
Imports System.Web.Routing
Imports System.Net.Http

Public Class WebApiApplication
    Inherits HttpApplication
    'tes
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim config As New HttpConfiguration
        RouteTable.Routes.MapHttpRoute(name:="DefaultApi",
                                       routeTemplate:="api/{controller}/{id}",
                                       defaults:=New With {.id = RouteParameter.Optional})
        GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()


        Dim config2 As New HttpConfiguration
        RouteTable.Routes.MapHttpRoute(name:="PenggunaApi",
                                       routeTemplate:="api/pengguna/{user}/{pass}",
                                       defaults:=New With
    {
       .Controller = "pengguna",
       .ConvertFromMeasureId = RouteParameter.Optional,
       .ConvertFromAmount = RouteParameter.Optional,
       .ConvertToMeasureId = RouteParameter.Optional,
       .MeasureDefinition = RouteParameter.Optional
    })


        '    RouteTable.Routes.MapHttpRoute(name:="InsertApi",
        '                                   routeTemplate:="api/{controller}/{action}/{id}",
        '                                   defaults:=New With
        '{
        '   .Controller = "InsertCheckIn",
        '   .ConvertFromMeasureId = RouteParameter.Optional,
        '   .ConvertFromAmount = RouteParameter.Optional,
        '   .ConvertToMeasureId = RouteParameter.Optional,
        '   .MeasureDefinition = RouteParameter.Optional,
        '   .id = RouteParameter.Optional
        '})

        RouteTable.Routes.MapHttpRoute(
                name:="InsertApi",
                routeTemplate:="api/{controller}/{id}",
                defaults:=New With {.id = RouteParameter.Optional}
            )

        GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()
        'GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Clear()
        'GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Clear() '.Add(New MediaTypeHeaderValue("application/pdf"))
        'GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("application/pdf"))

    End Sub
End Class
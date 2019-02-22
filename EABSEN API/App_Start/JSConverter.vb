Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Web.Script.Serialization

Namespace System.Web.Script.Serialization.CS
    Public Class JSConverter
        Inherits JavaScriptConverter

        Public Overrides ReadOnly Property SupportedTypes As IEnumerable(Of Type)
            Get
                Return New ReadOnlyCollection(Of Type)(New List(Of Type)(New Type() {GetType(ListItemCollection)}))
            End Get
        End Property

        Public Overrides Function Serialize(ByVal obj As Object, ByVal serializer As JavaScriptSerializer) As IDictionary(Of String, Object)
            Dim listType As ListItemCollection = TryCast(obj, ListItemCollection)

            If listType IsNot Nothing Then
                Dim result As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                Dim itemsList As ArrayList = New ArrayList()

                For Each item As ListItem In listType
                    Dim listDict As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                    listDict.Add("Value", item.Value)
                    listDict.Add("Text", item.Text)
                    itemsList.Add(listDict)
                Next

                result("List") = itemsList
                Return result
            End If

            Return New Dictionary(Of String, Object)()
        End Function

        Public Overrides Function Deserialize(ByVal dictionary As IDictionary(Of String, Object), ByVal type As Type, ByVal serializer As JavaScriptSerializer) As Object
            If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")

            If type = GetType(ListItemCollection) Then
                Dim list As ListItemCollection = New ListItemCollection()
                Dim itemsList As ArrayList = CType(dictionary("List"), ArrayList)

                For i As Integer = 0 To itemsList.Count - 1
                    list.Add(serializer.ConvertToType(Of ListItem)(itemsList(i)))
                Next

                Return list
            End If

            Return Nothing
        End Function
    End Class
End Namespace

Namespace System.Web.Script.Serialization.CS
    Public Class ListItemCollectionConverter
        Inherits JavaScriptConverter

        Public Overrides ReadOnly Property SupportedTypes As IEnumerable(Of Type)
            Get
                Return New ReadOnlyCollection(Of Type)(New List(Of Type)(New Type() {GetType(ListItemCollection)}))
            End Get
        End Property

        Public Overrides Function Serialize(ByVal obj As Object, ByVal serializer As JavaScriptSerializer) As IDictionary(Of String, Object)
            Dim listType As ListItemCollection = TryCast(obj, ListItemCollection)

            If listType IsNot Nothing Then
                Dim result As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                Dim itemsList As ArrayList = New ArrayList()

                For Each item As ListItem In listType
                    Dim listDict As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                    listDict.Add("Value", item.Value)
                    listDict.Add("Text", item.Text)
                    itemsList.Add(listDict)
                Next

                result("List") = itemsList
                Return result
            End If

            Return New Dictionary(Of String, Object)()
        End Function

        Public Overrides Function Deserialize(ByVal dictionary As IDictionary(Of String, Object), ByVal type As Type, ByVal serializer As JavaScriptSerializer) As Object
            If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")

            If type = GetType(ListItemCollection) Then
                Dim list As ListItemCollection = New ListItemCollection()
                Dim itemsList As ArrayList = CType(dictionary("List"), ArrayList)

                For i As Integer = 0 To itemsList.Count - 1
                    list.Add(serializer.ConvertToType(Of ListItem)(itemsList(i)))
                Next

                Return list
            End If

            Return Nothing
        End Function
    End Class
End Namespace


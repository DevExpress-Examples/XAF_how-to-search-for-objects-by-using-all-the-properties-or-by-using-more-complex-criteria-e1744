Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule

Namespace Dennis.Search.Win
    Public Class SearchObjectViewController
        Inherits ViewController

        Private Const ActiveKeySearchObject As String = "ISearchObject"
        Private scaSearchObjectActionCore As SingleChoiceAction
        Public Const SearchResultsCollectionName As String = "SearchResults"
        Public Sub New()
            scaSearchObjectActionCore = New SingleChoiceAction(Me, "SearchObject", PredefinedCategory.Search)
            AddHandler scaSearchObjectActionCore.Execute, AddressOf saSearchObjectActionCore_Execute
            scaSearchObjectActionCore.Caption = My.Resources.SearchObjectActionText
            scaSearchObjectActionCore.ImageName = "Action_Search"
            scaSearchObjectActionCore.ItemType = SingleChoiceActionItemType.ItemIsOperation
        End Sub
        Public ReadOnly Property SearchObjectAction() As SingleChoiceAction
            Get
                Return scaSearchObjectActionCore
            End Get
        End Property
        Private Sub saSearchObjectActionCore_Execute(ByVal sender As Object, ByVal args As SingleChoiceActionExecuteEventArgs)
            SearchObject(args)
        End Sub
        Protected Overridable Sub SearchObject(ByVal args As SingleChoiceActionExecuteEventArgs)
            Dim type As Type = CType(args.SelectedChoiceActionItem.Data, Type)
            Dim os As IObjectSpace = Application.CreateObjectSpace(type)
            Dim obj As Object = os.CreateObject(type)
            Dim dv As DetailView = Application.CreateDetailView(os, obj)
            args.ShowViewParameters.CreatedView = dv
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            InitSearchObjectActionItems()
            If GetType(ISearchObject).IsAssignableFrom(View.ObjectTypeInfo.Type) Then
                Dim dv As DetailView = TryCast(View, DetailView)
                If dv IsNot Nothing Then
                    For Each editor As ListPropertyEditor In dv.GetItems(Of ListPropertyEditor)()
                        If editor.PropertyName = SearchResultsCollectionName Then
                            AddHandler editor.ControlCreated, AddressOf editor_ControlCreated
                        End If
                    Next editor
                    Dim refreshController As RefreshController = Frame.GetController(Of RefreshController)()
                    If refreshController IsNot Nothing Then
                        refreshController.RefreshAction.Active(ActiveKeySearchObject) = False
                    End If
                    Dim recordsNavigationController As RecordsNavigationController = Frame.GetController(Of RecordsNavigationController)()
                    If recordsNavigationController IsNot Nothing Then
                        recordsNavigationController.PreviousObjectAction.Active(ActiveKeySearchObject) = False
                        recordsNavigationController.NextObjectAction.Active(ActiveKeySearchObject) = False
                    End If
                    Dim modificationsController As ModificationsController = Frame.GetController(Of ModificationsController)()
                    If modificationsController IsNot Nothing Then
                        modificationsController.SaveAction.Active(ActiveKeySearchObject) = False
                        modificationsController.SaveAndCloseAction.Active(ActiveKeySearchObject) = False
                        modificationsController.CancelAction.Active(ActiveKeySearchObject) = False
                    End If
                    Dim deleteObjectsViewController As DeleteObjectsViewController = Frame.GetController(Of DeleteObjectsViewController)()
                    If deleteObjectsViewController IsNot Nothing Then
                        deleteObjectsViewController.DeleteAction.Active(ActiveKeySearchObject) = False
                    End If
                    Dim newObjectViewController As NewObjectViewController = Frame.GetController(Of NewObjectViewController)()
                    If newObjectViewController IsNot Nothing Then
                        newObjectViewController.NewObjectAction.Active(ActiveKeySearchObject) = False
                    End If
                End If
                SearchObjectAction.Active(ActiveKeySearchObject) = False
            End If
        End Sub
        Private Sub editor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim editor As ListPropertyEditor = DirectCast(sender, ListPropertyEditor)
            RemoveHandler editor.ControlCreated, AddressOf editor_ControlCreated
            Dim linkUnlinkController As LinkUnlinkController = editor.Frame.GetController(Of LinkUnlinkController)()
            If linkUnlinkController IsNot Nothing Then
                linkUnlinkController.LinkAction.Active(ActiveKeySearchObject) = False
                linkUnlinkController.UnlinkAction.Active(ActiveKeySearchObject) = False
            End If
            Dim deleteObjectsViewController As DeleteObjectsViewController = editor.Frame.GetController(Of DeleteObjectsViewController)()
            If deleteObjectsViewController IsNot Nothing Then
                deleteObjectsViewController.DeleteAction.Active(ActiveKeySearchObject) = False
            End If
            Dim newObjectViewController As NewObjectViewController = editor.Frame.GetController(Of NewObjectViewController)()
            If newObjectViewController IsNot Nothing Then
                newObjectViewController.NewObjectAction.Active(ActiveKeySearchObject) = False
            End If
        End Sub
        Private Sub InitSearchObjectActionItems()
            SearchObjectAction.BeginUpdate()
            SearchObjectAction.Items.Clear()
            Dim genericType As Type = GetType(SearchObjectBase(Of )).MakeGenericType(View.ObjectTypeInfo.Type)
            Dim imageName As String = View.Model.ImageName
            For Each typeInfo As ITypeInfo In XafTypesInfo.Instance.PersistentTypes
                If genericType.IsAssignableFrom(typeInfo.Type) AndAlso Not typeInfo.IsAbstract Then
                    Dim item As New ChoiceActionItem(CaptionHelper.GetClassCaption(typeInfo.FullName), typeInfo.Type)
                    item.ImageName = imageName
                    SearchObjectAction.Items.Add(item)
                End If
            Next typeInfo
            SearchObjectAction.EndUpdate()
        End Sub
    End Class
End Namespace
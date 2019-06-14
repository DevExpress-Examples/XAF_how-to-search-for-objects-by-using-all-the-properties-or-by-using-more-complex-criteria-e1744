using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;

namespace Dennis.Search.Win {
    public class SearchObjectViewController : ViewController {
        private const string ActiveKeySearchObject = "ISearchObject";
        private SingleChoiceAction scaSearchObjectActionCore;
        public const string SearchResultsCollectionName = "SearchResults";
        public SearchObjectViewController() {
            scaSearchObjectActionCore = new SingleChoiceAction(this, "SearchObject", PredefinedCategory.Search);
            scaSearchObjectActionCore.Execute += saSearchObjectActionCore_Execute;
            scaSearchObjectActionCore.Caption = Properties.Resources.SearchObjectActionText;
            scaSearchObjectActionCore.ImageName = "Action_Search";
            scaSearchObjectActionCore.ItemType = SingleChoiceActionItemType.ItemIsOperation;
        }
        public SingleChoiceAction SearchObjectAction {
            get { return scaSearchObjectActionCore; }
        }
        private void saSearchObjectActionCore_Execute(object sender, SingleChoiceActionExecuteEventArgs args) {
            SearchObject(args);
        }
        protected virtual void SearchObject(SingleChoiceActionExecuteEventArgs args) {
            Type type = (Type)args.SelectedChoiceActionItem.Data;
            IObjectSpace os = Application.CreateObjectSpace(type);
            object obj = os.CreateObject(type);
            DetailView dv = Application.CreateDetailView(os, obj);
            args.ShowViewParameters.CreatedView = dv;
        }
        protected override void OnActivated() {
            base.OnActivated();
            InitSearchObjectActionItems();
            if(typeof(ISearchObject).IsAssignableFrom(View.ObjectTypeInfo.Type)) {
                DetailView dv = View as DetailView;
                if(dv != null) {
                    foreach(ListPropertyEditor editor in dv.GetItems<ListPropertyEditor>())
                        if(editor.PropertyName == SearchResultsCollectionName)
                            editor.ControlCreated += new EventHandler<EventArgs>(editor_ControlCreated);
                    RefreshController refreshController = Frame.GetController<RefreshController>();
                    if(refreshController != null) {
                        refreshController.RefreshAction.Active[ActiveKeySearchObject] = false;
                    }
                    RecordsNavigationController recordsNavigationController = Frame.GetController<RecordsNavigationController>();
                    if(recordsNavigationController != null) {
                        recordsNavigationController.PreviousObjectAction.Active[ActiveKeySearchObject] = false;
                        recordsNavigationController.NextObjectAction.Active[ActiveKeySearchObject] = false;
                    }
                    ModificationsController modificationsController = Frame.GetController<ModificationsController>();
                    if(modificationsController != null) {
                        modificationsController.SaveAction.Active[ActiveKeySearchObject] = false;
                        modificationsController.SaveAndCloseAction.Active[ActiveKeySearchObject] = false;
                        modificationsController.CancelAction.Active[ActiveKeySearchObject] = false;
                    }
                    DeleteObjectsViewController deleteObjectsViewController = Frame.GetController<DeleteObjectsViewController>();
                    if(deleteObjectsViewController != null) {
                        deleteObjectsViewController.DeleteAction.Active[ActiveKeySearchObject] = false;
                    }
                    NewObjectViewController newObjectViewController = Frame.GetController<NewObjectViewController>();
                    if(newObjectViewController != null) {
                        newObjectViewController.NewObjectAction.Active[ActiveKeySearchObject] = false;
                    }
                }
                SearchObjectAction.Active[ActiveKeySearchObject] = false;
            }
        }
        private void editor_ControlCreated(object sender, EventArgs e) {
            ListPropertyEditor editor = (ListPropertyEditor)sender;
            editor.ControlCreated -= new EventHandler<EventArgs>(editor_ControlCreated);
            LinkUnlinkController linkUnlinkController = editor.Frame.GetController<LinkUnlinkController>();
            if(linkUnlinkController != null) {
                linkUnlinkController.LinkAction.Active[ActiveKeySearchObject] = false;
                linkUnlinkController.UnlinkAction.Active[ActiveKeySearchObject] = false;
            }
            DeleteObjectsViewController deleteObjectsViewController = editor.Frame.GetController<DeleteObjectsViewController>();
            if(deleteObjectsViewController != null) {
                deleteObjectsViewController.DeleteAction.Active[ActiveKeySearchObject] = false;
            }
            NewObjectViewController newObjectViewController = editor.Frame.GetController<NewObjectViewController>();
            if(newObjectViewController != null) {
                newObjectViewController.NewObjectAction.Active[ActiveKeySearchObject] = false;
            }
        }
        private void InitSearchObjectActionItems() {
            SearchObjectAction.BeginUpdate();
            SearchObjectAction.Items.Clear();
            Type genericType = typeof(SearchObjectBase<>).MakeGenericType(View.ObjectTypeInfo.Type);
            string imageName = View.Model.ImageName;
            foreach (ITypeInfo typeInfo in XafTypesInfo.Instance.PersistentTypes) {
                if (genericType.IsAssignableFrom(typeInfo.Type) && !typeInfo.IsAbstract) {
                    ChoiceActionItem item = new ChoiceActionItem(CaptionHelper.GetClassCaption(typeInfo.FullName), typeInfo.Type);
                    item.ImageName = imageName;
                    SearchObjectAction.Items.Add(item);
                }
            }
            SearchObjectAction.EndUpdate();
        }
    }
}
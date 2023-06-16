using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using dxTestSolution.Module.BusinessObjects;

namespace dxTestSolution.Module.Controllers {
    public class MyShowSearchController : ObjectViewController<ListView, Contact> {
        public MyShowSearchController() {
            var mypopAction1 = new PopupWindowShowAction(this, "MyShowSearchAction", PredefinedCategory.Edit);
            mypopAction1.CustomizePopupWindowParams += MyAction1_CustomizePopupWindowParams;

        }
        private void MyAction1_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            var nonPersistentOS = Application.CreateObjectSpace(typeof(MySearchClass));
            var persistentOS = Application.CreateObjectSpace(typeof(Contact));
            ((NonPersistentObjectSpace)nonPersistentOS).AdditionalObjectSpaces.Add(persistentOS);
            var obj = nonPersistentOS.CreateObject<MySearchClass>();
            nonPersistentOS.CommitChanges();
            var view = Application.CreateDetailView(nonPersistentOS, obj);
            e.View = view;
        }

    }
}

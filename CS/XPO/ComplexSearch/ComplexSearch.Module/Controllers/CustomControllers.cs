using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using dxTestSolution.Module.BusinessObjects;

using System.IO;
using System.ComponentModel;

namespace dxTestSolution.Module.Controllers {
    public class MyShowSearchController : ObjectViewController<ListView, Contact> {
        public MyShowSearchController() {
            var mypopAction1 = new PopupWindowShowAction(this, "MyShowSearchAction", PredefinedCategory.Edit);
            mypopAction1.CustomizePopupWindowParams += MyAction1_CustomizePopupWindowParams;

        }
        private void MyAction1_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            var os = Application.CreateObjectSpace(typeof(MySearchClass));
            var obj = os.CreateObject<MySearchClass>();
            var view = Application.CreateDetailView(os, obj);
            e.View = view;
        }

    }

    public class MySearchController : ObjectViewController<DetailView, MySearchClass> {
        public MySearchController() {
            var myAction1 = new SimpleAction(this, "MySearch", "MySearchCategory");
            myAction1.Execute += MyAction1_Execute;

        }

        private void MyAction1_Execute(object sender, SimpleActionExecuteEventArgs e) {
            var mySearchObject = (MySearchClass)View.CurrentObject;

            var persistentOS = Application.CreateObjectSpace(typeof(Contact));
            var criterion = CriteriaOperator.FromLambda<Contact>(x => x.FirstName.Contains(mySearchObject.FirstName) || x.Age == mySearchObject.Age);

            var results = persistentOS.GetObjects<Contact>(criterion);

            mySearchObject.SetContacts(results);


            //var os = Application.CreateObjectSpace(typeof(MyNonPersistentClass));
            //var obj = os.CreateObject<MyNonPersistentClass>();
            //var detailView = Application.CreateDetailView(os, obj);
        }


    }
}

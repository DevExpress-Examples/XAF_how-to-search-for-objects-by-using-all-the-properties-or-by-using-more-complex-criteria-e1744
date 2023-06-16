using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using dxTestSolution.Module.BusinessObjects;

namespace dxTestSolution.Module.Controllers {

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

        }


    }
}

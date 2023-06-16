using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.BaseImpl;

namespace dxTestSolution.Module.BusinessObjects {
    [DomainComponent]
    public class MySearchClass : NonPersistentBaseObject {
        [XafDisplayName("FirstName contains:")]
        public string FirstName { get; set; }
        [XafDisplayName("Age is equal to:")]
        public int Age { get; set; }
        public void SetContacts(IList<Contact> res) {
            _contacts = res;
            OnPropertyChanged(nameof(Contacts));
        }
        private IList<Contact> _contacts = new List<Contact>();
        [XafDisplayName("Results:")]
        public IList<Contact> Contacts {
            get {
                return _contacts;
            }
        }
    }
}

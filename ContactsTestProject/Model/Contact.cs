using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ContactsTestProject.Model
{
    class Contact : INotifyPropertyChanged
    {

        #region Constructors

        public Contact()
        {
            //generate Id 
            this._Id = Guid.NewGuid().ToString();
            this.FirstName = "New";
            this.LastName = "Contact";
            this.DOB = DateTime.Now.AddYears(-25);
        }
      
        public Contact(String ID)
        {
            this._Id = ID;
        }
      
        public Contact(String ID, String FirstName, String LastName, DateTime DOB)
            : this(ID)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DOB = DOB;
        }
       
        public Contact(Contact contact)
            : this(contact.Id, contact.FirstName, contact.LastName, contact.DOB)
        {

        }
        #endregion
       
        
        #region Fields


        #region ID
        // a better design would use entity key class
        //but in our simple case it is just a GUID that saved to XML...
        private String _Id;
        public String Id { get { return this._Id; } }

        #endregion

        #region FirstName

        private String _FirstName;

        public String FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        #endregion

        #region LastName
        private String _LastName;

        public String LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        #endregion

        #region DOB
        private DateTime _DOB;

        public DateTime DOB
        {
            get { return _DOB; }
            set
            {
                if (_DOB != value)
                {
                    _DOB = value;
                    NotifyPropertyChanged("DOB");
                }
            }
        }
        #endregion


        #endregion
     
        
        #region INotifyPropertyChanged Members and implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String PropertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion

    }
}

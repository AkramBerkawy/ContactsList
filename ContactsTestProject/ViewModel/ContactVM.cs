using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsTestProject.Common;
using System.Windows.Input;
using ContactsTestProject.Model;
using System.ComponentModel;
using System.Windows;

namespace ContactsTestProject.ViewModel
{
    class ContactVM : BaseViewModel,IDataErrorInfo
    {
        private bool isNew = false;
        Contact _Model;

        #region Events

        /// <summary>
        /// OnDelete event is raised when the current contact is deleted
        /// Of course in real application, it should use a mediator or messenger pattern to inform deletion
        /// </summary>
        public event EventHandler OnDelete;

        /// <summary>
        /// Request Close of parent Dialog (if exists)
        /// </summary>
        public event EventHandler RequestClose;
        #endregion //Events


        #region Constructor
        public ContactVM(Contact contact)
        {
            this._Model = contact;
        }
        public ContactVM(Contact contact,bool isNew):this(contact)
        {
            this.isNew = isNew;
        }

        #endregion
       
        #region Commands

        #region Save Command
        bool canSave(object param)
        {
            return true;
        }
        void ExecuteSave(Object param)
        {
            //validate before save
            var errorMessage = this.Error;
            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var repo = new ContactsRepository();
            if (this.isNew)
            {
                repo.Add(this._Model);
                this.isNew = false;
            }
            else
                repo.Update(this._Model);
            this.IsSaved = true;
            //request the dialog to cloase
            if (RequestClose != null)
                RequestClose(this, new EventArgs());
        }
        RelayCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return this._SaveCommand ??
                    (this._SaveCommand = new RelayCommand(canSave, ExecuteSave));
            }
        }  
        #endregion


        #region Delete Command
        bool canDelete(object para)
        {
            //user can delete saved Contacts only
            return !this.isNew;
        }

        void executeDelete(Object para)
        {
            var contactsRepo = new ContactsRepository();
            contactsRepo.Delete(this._Model);
            //raise OnDelete event to inform that this Contact Model has been deleted
            if (OnDelete != null)
                OnDelete(this, new EventArgs());
        }
        RelayCommand _deleteCommand;
        
        /// <summary>
        /// Delete command to delete this Contact from the storage
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? 
                    (_deleteCommand = new RelayCommand(canDelete, executeDelete));
            }
        }

        #endregion //delete command


        #region CancelEdit Command
        //note: it would be better if the viewmodel (or model!) implements IEditableObject, and both
        //      save and canel edit use it instead..
        bool canCancelEdit(object param)
        {
            return true;
        }
        void ExecuteCancelEdit(Object param)
        {
            var repo = new ContactsRepository();
            //new Conatcs that are not saved yet is not used anywere else,
            //so no need for doing any thing
            if (!this.isNew)
            {
                this._Model = repo.GetById(this._Model.Id);
                //notify View to update values
                //no need for this if the view binding was direct to model
                NotifyPropertyChanged("FirstName");
                NotifyPropertyChanged("LastName");
                NotifyPropertyChanged("DOB");
            }
            this.IsSaved = false;
            //request from dialog to close
            //no need for when DialogService pattern is used
            if (this.RequestClose != null)
            {
                RequestClose(this, new EventArgs());
            }
        }
        RelayCommand _CancelEditCommand;

        /// <summary>
        /// Caned Edit Command, called to revert and roll back changes applied to model
        /// </summary>
        public ICommand CancelEditCommand
        {
            get
            {
                return this._CancelEditCommand ?? 
                    (this._CancelEditCommand = new RelayCommand(canCancelEdit, ExecuteCancelEdit));
            }
        }
        #endregion

        #endregion

        #region Properties

        //Properties here only expose the model's properties ,no duplicaiton.
        // it is needed to have private storage fields if IEditableObject is implemented or for such operations
      
        //First Name 
        public String FirstName
        {
            get { return _Model.FirstName; }
            set
            {
                if (_Model.FirstName != value)
                {
                    _Model.FirstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        //Last Name
        public String LastName
        {
            get { return _Model.LastName; }
            set
            {
                if (_Model.LastName != value)
                {
                    _Model.LastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public DateTime DOB
        {
            get { return _Model.DOB; }
            set
            {
                if (_Model.DOB != value)
                {
                    _Model.DOB = value;
                    NotifyPropertyChanged("DOB");
                }
            }
        }


        private bool _IsSaved;

        public bool IsSaved
        {
            get { return _IsSaved; }
            set
            {
                _IsSaved = value;
                NotifyPropertyChanged("IsSaved");
            }
        }

        #endregion
      
        #region IDataErrorInfo Implementation

        public string Error
        {
            get
            {
                // join errors with new line, skipping empty errors(nulls) to not showing empty lines
                String[] Errors = { this["FirstName"], this["LastName"], this["DOB"] };
                return String.Join("." + Environment.NewLine, Errors.Where(e => !string.IsNullOrEmpty(e)));
            }
        }
        // a better implementation would use ValidationRule pattern, and resource based error messages
        public string this[string columnName]
        {
            get
            {
                String errorString = null;
                
                    if(columnName== "FirstName"){
                        if(String.IsNullOrEmpty(this.FirstName))
                            errorString = "First Name is Required field";
                    }
                    else if (columnName == "LastName")
                    {
                        if (String.IsNullOrEmpty(this.LastName))
                            errorString = "Last Name is Required field";
                    }
                    else if(columnName =="DOB"){
                        var age = Util.Utility.CalculateAge(DOB);
                        if (age < 18 || age > 100)
                            errorString ="Age must be between 18 and 100 Year";
                    }

                    return errorString;
            }
        } 
        #endregion



    }
}

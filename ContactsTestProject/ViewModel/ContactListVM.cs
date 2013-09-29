using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsTestProject.Common;
using System.Collections.ObjectModel;
using ContactsTestProject.Model;
using System.Windows.Input;
using ContactsTestProject.View;
namespace ContactsTestProject.ViewModel
{
    class ContactListVM : BaseViewModel
    {

        #region Constructors

        public ContactListVM()
        {
            var contactsRepo = new ContactsRepository();
            var allContacts = contactsRepo.GetAll();
            this.Contacts = new ObservableCollection<ContactVM>();
            //create Contact ViewModel for each of the loaded contact model
            foreach (var contact in allContacts)
            {
                var contactVM = new ContactVM(contact);
                contactVM.OnDelete += new EventHandler(contactVM_OnDelete);
                //and add it to the Contacts Collection
                Contacts.Add(contactVM);
            }
        } 
        #endregion

        #region private members
        //remove the ContactVM from the collection when it is deleted
        //TODO: use a mediator or application messenger to communicate between ViewModels
        void contactVM_OnDelete(object sender, EventArgs e)
        {
            var DeletedContactVM = sender as ContactVM;
            this.Contacts.Remove(DeletedContactVM);
        }
        #endregion

        #region Members
        private ObservableCollection<ContactVM> _Contacts;
        /// <summary>
        /// Contacts ViewModel Observable Collection
        /// </summary>
        public ObservableCollection<ContactVM> Contacts
        {
            get { return _Contacts; }
            set
            {
                if (_Contacts != value)
                {
                    _Contacts = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        } 
       
        private ContactVM _SelectedContact;
        /// <summary>
        /// Contact currently selected from the Collection
        /// </summary>
        public ContactVM SelectedContact
        {
            get { return _SelectedContact; }
            set
            {
                if (_SelectedContact != value)
                { _SelectedContact = value;
                NotifyPropertyChanged("SelectedContact");
                }
            }
        }

        #endregion //Members

        #region Commands

        #region Add Command
        bool canAdd(object o)
        {
            return true;
        }
        void executeAdd(object o)
        {
            //create new ContactView Model with new initialized Contact Model
            ContactVM cvm = new ContactVM(new Contact(),true);
            //create Contact Edit dialog and set its data context to the created Contact ViewModel
            //TODO: in real and larger applicaiton we should use application dialog service to create and initialize
            //dialogs
            ContactEditDialog dlg = new ContactEditDialog()
            {
                DataContext = cvm
            };

            //close the dialog when VM raise RequestClose event
            cvm.RequestClose += delegate { dlg.Close(); };

            dlg.ShowDialog();
            //add the Contact View model to the collection only when it has beed saved
            if (cvm.IsSaved)
            {
                //TODO: instead use messenger or mediator  to handle ViewModel add message
                Contacts.Add(cvm);
            }
        }
        RelayCommand _addCommand;
        
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(canAdd, executeAdd));
            }
        } 
        #endregion //add command

        #region Edit Command
        
        RelayCommand _editCommnd;
        bool canEdit(Object o) { 
            //can edit only if there is contact selected
            return this.SelectedContact!=null;
        }
        void executeEdit(Object o)
        {
            //show edit dialog, and set its data context to the selected ContactVM
            var dialog = new View.ContactEditDialog();
            dialog.DataContext = SelectedContact;
            var closedByVM = false;
            //close the dialog when VM raise RequestClose event
            SelectedContact.RequestClose += delegate { closedByVM = true;  dialog.Close(); };
            
            //cancel edit changes if the dialog has been closed by user
            //a real applicaiotn should ask user for confirmation and so, take action based on user decision...
            dialog.Closed += delegate { 
                if (!closedByVM)
                    SelectedContact.CancelEditCommand.Execute(null); 
            };
            dialog.ShowDialog();
        }
        //command to Edit selected Contact
        public ICommand EditCommand
        {
            get
            {
                return _editCommnd ?? 
                    (_editCommnd = new RelayCommand(canEdit, executeEdit));
            }
        }

        #endregion //Edit command


        #region Delete Command
        bool canDelete(object para)
        {
            return SelectedContact != null && SelectedContact.DeleteCommand.CanExecute(para);
        }

        void executeDelete(Object para)
        {
            SelectedContact.DeleteCommand.Execute(para);
        }
        RelayCommand _deleteCommand;
        //the delete command is on ContactVM level, we use this command as proxy to it.
        //this allow delete a contact either when opened for edit, or here from the list
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? 
                    (_deleteCommand = new RelayCommand(canDelete, executeDelete));
            }
        }

        #endregion //delete command



        #endregion //commands

    }
}

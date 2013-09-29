using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ContactsTestProject.Common
{
    /// <summary>
    /// BaseViewModel the base class for ViewModel
    /// It implements INotifyProperyChanged
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion //INotifyPropertyChanged Implementation 
    }
}

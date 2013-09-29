using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ContactsTestProject.Common
{
    /// <summary>
    /// RelayCommand: Josh Smith implementation of Relay command
    /// </summary>
    class RelayCommand : ICommand
    {

        #region Constructors

        public RelayCommand(Action<object> action)
        {
            this.action = action;
        }
        public RelayCommand(Predicate<object> predicate, Action<object> action)
        {
            this.action = action;
            this.predicate = predicate;
        } 
        #endregion

        #region ICommand Implementation

        public bool CanExecute(object parameter)
        {
            return (this.predicate == null) ? true : this.predicate(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            this.action(parameter);
        } 
        #endregion

        #region Fields

        readonly Predicate<object> predicate;
        readonly Action<object> action;

        #endregion
  
    }
}

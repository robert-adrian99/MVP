using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfXMLSerialization.ViewModels
{
    class RelayCommand : ICommand
    {
        private Func<object, object> commandTask;

        public RelayCommand(Func<object, object> workToDo)
        {
            commandTask = workToDo;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}

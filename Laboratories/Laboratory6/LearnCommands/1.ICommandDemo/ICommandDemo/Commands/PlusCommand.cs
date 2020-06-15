using ICommandDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandDemo.Commands
{
    class PlusCommand : ICommand
    {
        // Creating private field of CalculatorViewModel and passing calculatorViewModel into the constructor
        private CalculatorViewModel calculatorVM;
        public PlusCommand(CalculatorViewModel calculatorVM)
        {
            this.calculatorVM = calculatorVM;
        }

        public void Add()
        {
            calculatorVM.Output = calculatorVM.FirstValue + calculatorVM.SecondValue;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Add();
        }

        public event EventHandler CanExecuteChanged;
    }
}

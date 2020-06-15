using ICommandDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandDemo.Commands
{
    class MultiplyCommand : ICommand
    {
        // Creating private field of CalculatorViewModel and passing calculatorViewModel into the constructor
        private CalculatorViewModel calculatorVM;
        public MultiplyCommand(CalculatorViewModel calculatorVM)
        {
            this.calculatorVM = calculatorVM;
        }

        public void Multiply()
        {
            calculatorVM.Output = calculatorVM.FirstValue * calculatorVM.SecondValue;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Multiply();
        }

        public event EventHandler CanExecuteChanged;
    }
}

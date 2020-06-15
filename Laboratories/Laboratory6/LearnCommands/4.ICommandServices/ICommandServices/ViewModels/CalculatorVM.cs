using ICommandServices.Commands;
using ICommandServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandServices.ViewModels
{
    class CalculatorVM : BaseVM
    {
        private CalculatorOperations operation;

        public CalculatorVM()
        {
            operation  = new CalculatorOperations(this);
        }

        private double firstValue;
        public double FirstValue
        {
            get
            {
                return firstValue;
            }
            set
            {
                firstValue = value;
                canExecuteCommand = MyValidator.CanExecuteOperation(FirstValue, SecondValue);
            }
        }

        private double secondValue;
        public double SecondValue
        {
            get
            {
                return secondValue;
            }
            set
            {
                secondValue = value;
                canExecuteCommand = MyValidator.CanExecuteOperation(FirstValue, SecondValue);
            }
        }

        private double output;
        public double Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }

        private bool canExecuteCommand = false;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }

        private ICommand plusCommand;
        public ICommand AddCommand
        {
            get
            {
                if (plusCommand == null)
                {
                    plusCommand = new RelayCommand(operation.Add, param => CanExecuteCommand);
                }
                return plusCommand;
            }
        }

        private ICommand subCommand;
        public ICommand SubstractCommand
        {
            get
            {
                if (subCommand == null)
                {
                    subCommand = new RelayCommand(operation.Substract, param => CanExecuteCommand);
                }
                return subCommand;
            }
        }

        private ICommand multiCommand;
        public ICommand MultiplyCommand
        {
            get
            {
                if (multiCommand == null)
                {
                    multiCommand = new RelayCommand(operation.Multiply, param => CanExecuteCommand);
                }
                return multiCommand;
            }
        }

        private ICommand divCommand;
        public ICommand DivideCommand
        {
            get
            {
                if (divCommand == null)
                {
                    divCommand = new RelayCommand(operation.Divide, param => CanExecuteCommand);
                }
                return divCommand;
            }
        }
    }
}

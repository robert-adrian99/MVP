using ICommandCanExecuteDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandCanExecuteDemo.ViewModels
{
    class CalculatorVM : BaseVM
    {
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
                if (firstValue == 0 || secondValue == 0)
                {
                    canExecuteCommand = false;
                }
                else
                {
                    canExecuteCommand = true;
                }
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
                if (firstValue == 0 || secondValue == 0)
                {
                    canExecuteCommand = false;
                }
                else
                {
                    canExecuteCommand = true;
                }
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
                // daca atributul canExecuteCommand nu si-a schimbat valoarea, iese fortat din setter
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }

        //pt butonul +
        public void Add(object param)
        {
            Output = FirstValue + SecondValue;
        }

        private ICommand plusCommand;
        public ICommand AddCommand
        {
            get
            {
                if (plusCommand == null)
                    plusCommand = new RelayCommand(Add);
                return plusCommand;
            }
        }

        //pt butonul -
        public void Substract(object param)
        {
            Output = FirstValue - SecondValue;
        }

        private ICommand subCommand;
        public ICommand SubstractCommand
        {
            get
            {
                if (subCommand == null)
                    subCommand = new RelayCommand(Substract, param => CanExecuteCommand);
                return subCommand;
            }
        }

        //pt butonul *
        public void Multiply(object param)
        {
            Output = FirstValue * SecondValue;
        }

        private ICommand multiCommand;
        public ICommand MultiplyCommand
        {
            get
            {
                if (multiCommand == null)
                    multiCommand = new RelayCommand(Multiply, param => CanExecuteCommand);
                return multiCommand;
            }
        }

        //pt butonul %
        public void Divide(object param)
        {
            Output = FirstValue % SecondValue;
        }

        private ICommand divCommand;
        public ICommand DivideCommand
        {
            get
            {
                if (divCommand == null)
                    divCommand = new RelayCommand(Divide, param => CanExecuteCommand);
                return divCommand;
            }
        }
    }
}

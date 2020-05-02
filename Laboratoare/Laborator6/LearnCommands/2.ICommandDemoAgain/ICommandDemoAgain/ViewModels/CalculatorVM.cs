using ICommandDemoAgain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandDemoAgain.ViewModels
{
    class CalculatorVM : BaseVM
    {
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }

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
                    subCommand = new RelayCommand(Substract);
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
                    multiCommand = new RelayCommand(Multiply);
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
                    divCommand = new RelayCommand(Divide);
                return divCommand;
            }
        }
    }
}

using ICommandDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandDemo.ViewModels
{
    class CalculatorViewModel: BaseViewModel
    {
        private PlusCommand plusCommand;
        private DivisionCommand divCommand;
        private MultiplyCommand multiCommand;
        private SubstractCommand subCommand;

        public CalculatorViewModel()
        {
            plusCommand = new PlusCommand(this);
            divCommand = new DivisionCommand(this);
            multiCommand = new MultiplyCommand(this);
            subCommand = new SubstractCommand(this);
        }

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

        public ICommand AddCommand
        {
            get
            {
                return plusCommand;
            }
        }

        public ICommand SubstractCommand
        {
            get
            {
                return subCommand;
            }
        }

        public ICommand MultiplyCommand
        {
            get
            {
                return multiCommand;
            }
        }

        public ICommand DivideCommand
        {
            get
            {
                return divCommand;
            }
        }
    }
}

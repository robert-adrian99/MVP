using ICommandServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICommandServices.Services
{
    class CalculatorOperations
    {
        private CalculatorVM calculatorVM;
        public CalculatorOperations(CalculatorVM calculatorVM)
        {
            this.calculatorVM = calculatorVM;
        }

        /*Initial aceste metode erau in ViewModel
         * Am mutat logica de acolo, dar aici trebuia sa stiu cine sunt cele 2 numere cu care operam
         * Nu puteam sa dau 2 double ca parametri pt Add, Substract, Multiply si Divide deoarece
         * delegatul Action<object> pe care il vor inlocui aceste metode la apel, in constructorul lui
         * RelayCommand, este parametrizat cu object, deci metodele trebuie sa aiba un object ca si parametru
         * Asa ca am facut un converter de la object la CalculatorVM....pt ca de acolo iau valorile
         * celor 2 nr cu care operez
         * ca sa stie aplicatia ca parametrul param al metodei este reprezentat de atributele lui
         * CalculatorVM, am specificat asta printr-un CommandParameter pe care l-am setat pt butoane.
         * In momentul in care actionez comanda, se transmit prin multi-binding si parametrii la comanda
         * si implicit si la metoda care se apeleaza la executia comenzii: Add, Substract...*/

        public void Add(object param)
        {
            CalculatorVM calcVM = param as CalculatorVM;
            calculatorVM.Output = calcVM.FirstValue + calcVM.SecondValue;
        }

        public void Substract(object param)
        {
            CalculatorVM calcVM = param as CalculatorVM;
            calculatorVM.Output = calcVM.FirstValue - calcVM.SecondValue;
        }

        public void Multiply(object param)
        {
            CalculatorVM calcVM = param as CalculatorVM;
            calculatorVM.Output = calcVM.FirstValue * calcVM.SecondValue;
        }

        public void Divide(object param)
        {
            CalculatorVM calcVM = param as CalculatorVM;
            calculatorVM.Output = calcVM.FirstValue % calcVM.SecondValue;
        }
    }
}

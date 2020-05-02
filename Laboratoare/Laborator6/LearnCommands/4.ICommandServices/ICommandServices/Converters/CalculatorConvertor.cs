using ICommandServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ICommandServices.Converters
{
    class CalculatorConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double val1 = 0, val2 = 0, rez = 0;
            Double.TryParse(values[0].ToString(), out val1);
            Double.TryParse(values[1].ToString(), out val2);
            Double.TryParse(values[2].ToString(), out rez);
            //CalculatorVM obj = new CalculatorVM();
            //obj.FirstValue = val1;
            //return obj;
            return new CalculatorVM()
            {
                FirstValue = val1,
                SecondValue = val2,
                Output = rez
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            CalculatorVM calcVM = value as CalculatorVM;
            object[] result = new object[3] { calcVM.FirstValue, calcVM.SecondValue, calcVM.Output };
            return result;
        }
    }
}

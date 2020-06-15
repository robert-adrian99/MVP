using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfMVVMAgendaEF.ViewModels;

namespace WpfMVVMAgendaEF.Converters
{
    class PhoneConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new PhoneVM()
            {
                PersonId = int.Parse(values[0].ToString()),
                PhoneNumber = values[1].ToString(),
                Description = values[2].ToString()
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            PhoneVM phone = value as PhoneVM;
            object[] result = new object[3] { phone.PersonId, phone.PhoneNumber, phone.Description };
            return result;
        }
    }
}

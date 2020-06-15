using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICommandServices.Services
{
    static class MyValidator
    {
        public static bool CanExecuteOperation(double firstValue, double secondValue)
        {
            if (firstValue == 0 || secondValue == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

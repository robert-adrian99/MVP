﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Exceptions
{
    class AgendaException:ApplicationException
    {
        public AgendaException(string message)
            : base(message)
        {
        }
    }
}

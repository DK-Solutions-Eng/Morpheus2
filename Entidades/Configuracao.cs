using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Configuracao : Base
    {
        public string porta_arduino { get; set; }
        public int baud_rate { get; set; }
    }
}

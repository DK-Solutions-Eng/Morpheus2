using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ItensReceita : Base
    {
        public int id_receita { get; set; }
        public string objetivo { get; set; }
        public string valor { get; set; }
        public string corte { get; set; }
        public string acao { get; set; }
        public string parametro1 { get; set; }
        public string parametro2 { get; set; }
        public string tipo_limite { get; set; }
        public string valor_limite { get; set; }
        public int sequencia { get; set; }
    }
}

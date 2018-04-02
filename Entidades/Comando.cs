using System;
using System.Data;

namespace Entidades
{
    public class Comando : Base
    {
        public string codigo_comando { get; set; }
        public string descricao_comando { get; set; }
        public int tipo { get; set; }

        TipoComando tipocomando { get; set; }
    }
}

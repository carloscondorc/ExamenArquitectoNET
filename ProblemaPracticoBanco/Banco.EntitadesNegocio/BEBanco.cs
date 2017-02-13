using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.EntitadadesNegocio
{
    public class BEBanco
    {

        public BEBanco()
        {

        }
        public BEBanco(int Banco_ID, string Banco_Nombre)
        {
            this.Banco_ID = 0;
            this.Banco_Nombre = "";
        }
        public int? Banco_ID { get; set; }
        public string Banco_Nombre { get; set; }
        public string Banco_Direccion { get; set; }
        public DateTime Banco_FechaRegistro { get; set; }
    }
}

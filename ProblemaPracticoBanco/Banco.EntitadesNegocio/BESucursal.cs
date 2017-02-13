using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.EntitadadesNegocio
{
    public class BESucursal
    {
        public int? Sucursal_ID { get; set; }
        public BEBanco Banco { get; set; }

        public int? Banco_ID { get; set; }
        public string Banco_Nombre { get; set; }
        public string Sucursal_Nombre { get; set; }
        public string Sucursal_Direccion { get; set; }
        public DateTime Sucursal_FechaRegistro { get; set; }

    }
}

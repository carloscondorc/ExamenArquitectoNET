using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.EntitadadesNegocio
{
    public class BEOrdenPago
    {

        public int? OrdenPago_ID { get; set; }
        public int? Sucursal_ID { get; set; }
        public int? Moneda_ID { get; set; }
        public int? EstadoOrden_ID { get; set; }
        public string Sucursal_Nombre { get; set; }
        public string Moneda_Nombre { get; set; }
        public string Moneda_Abreviatura { get; set; }
        public string EstadoOrden_Nombre { get; set; }
		public BESucursal Sucursal  {get;set;}
		public BEMoneda Moneda  {get;set;}
        public BEEstadoOrden EstadoOrden { get; set; }
        public decimal OrdenPago_Monto { get; set; }
        public string OrdenPago_Moneda { get; set; }
        public DateTime OrdenPago_FechaPago { get; set; } 
    }
}

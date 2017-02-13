using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banco.EntitadadesNegocio;

namespace Banco.Web.Models
{
    public class OrdenPagoViewModel : BEOrdenPago
    {
        public List<BEOrdenPago> ListaOrdenPago { get; set; }
        public List<SucursalViewModel> ListaSucursalCombo { get; set; }
        public List<MonedaViewModel> ListaMonedaCombo { get; set; }
        public List<EstadoOrdendenViewModel> ListaEstadoCombo { get; set; }
    }
}
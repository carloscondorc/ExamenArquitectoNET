using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banco.EntitadadesNegocio;

namespace Banco.Web.Models
{
    public class EstadoOrdendenViewModel :BEEstadoOrden
    {
        public List<BEOrdenPago> ListaEstado { get; set; }
    }
}
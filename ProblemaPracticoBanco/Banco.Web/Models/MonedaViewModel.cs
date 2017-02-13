using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banco.EntitadadesNegocio;

namespace Banco.Web.Models
{
    public class MonedaViewModel : BEMoneda
    {
        public List<BEMoneda> ListaMoneda { get; set; }
    }
}
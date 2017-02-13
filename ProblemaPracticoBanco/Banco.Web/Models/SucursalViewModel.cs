using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banco.EntitadadesNegocio;

namespace Banco.Web.Models
{
    public class SucursalViewModel : BESucursal
    {
        public List<BancoViewModel> ListaBancoCombo { get; set; }

        public List<BESucursal> ListaSucursal { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banco.EntitadadesNegocio;

namespace Banco.Web.Models
{
    public class BancoViewModel : BEBanco
    {
        public List<BEBanco> ListaBanco { get; set; }
    }
}
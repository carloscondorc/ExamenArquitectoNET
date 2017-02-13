using Banco.EntitadadesNegocio;
using Banco.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banco.WebAPI.Controllers
{
    public class BancoController : ApiController
    {


        // GET: api/Banco
   
        public IHttpActionResult GetBanco()
        {
            BLBanco oblBanco = new BLBanco();
            List<BEBanco> lstBanco = new List<BEBanco>();
            lstBanco = oblBanco.ConsultarBanco(new BEBanco()).ToList();

            return Ok(lstBanco);
        }


    }
}

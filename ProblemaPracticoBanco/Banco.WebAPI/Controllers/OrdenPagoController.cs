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
    public class OrdenPagoController : ApiController
    {


        // GET: api/OrdenPago/5
        [HttpGet]
        public IHttpActionResult ListaOrdenPago([FromUri] BEOrdenPago obeOrdenPago)
        {

            // BEOrdenPago obeOrdenPago = new BEOrdenPago() { Sucursal_ID = Sucursal_ID };
            BLBanco oblBanco = new BLBanco();
            List<BEOrdenPago> lstOrdenPago = new List<BEOrdenPago>();
            lstOrdenPago = oblBanco.ConsultarOrdenPago(obeOrdenPago).ToList();

            return Ok(lstOrdenPago);
        }

    }
}

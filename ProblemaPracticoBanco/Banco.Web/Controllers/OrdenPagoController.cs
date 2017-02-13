using Banco.EntitadadesNegocio;
using Banco.LogicaNegocio;
using Banco.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Banco.Web.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: OrdenPago
        BLBanco oblBanco;
        public OrdenPagoController()
        {
            oblBanco = new BLBanco();
        }
        public ActionResult Index()
        {
  
            OrdenPagoViewModel OrdenPagoVW = new OrdenPagoViewModel();
            List<BEOrdenPago> lstOrdenPago = new List<BEOrdenPago>();
            lstOrdenPago = oblBanco.ConsultarOrdenPago(new BEOrdenPago());
            ////Verificar
            OrdenPagoVW.ListaOrdenPago = lstOrdenPago;

            return View(OrdenPagoVW);
        }

         //GET: OrdenPago/Details/5
        public ActionResult Lista()
        {
    
            OrdenPagoViewModel OrdenPagoVW = new OrdenPagoViewModel();

            OrdenPagoVW.ListaOrdenPago = new List<BEOrdenPago>();

            List<BESucursal> lstSucursal = new List<BESucursal>();
            lstSucursal = oblBanco.ConsultarSucursales(new BESucursal());

            OrdenPagoVW.ListaSucursalCombo = lstSucursal.Select(e => new SucursalViewModel { Sucursal_ID = e.Sucursal_ID, Sucursal_Nombre = e.Sucursal_Nombre }).ToList();

            List<BEMoneda> lstMoneda = new List<BEMoneda>();
            lstMoneda = oblBanco.ConsultarMoneda(new BEMoneda());

            OrdenPagoVW.ListaMonedaCombo = lstMoneda.Select(e => new MonedaViewModel { Moneda_ID = e.Moneda_ID, Moneda_Nombre = e.Moneda_Nombre }).ToList(); ;

            return View(OrdenPagoVW);
        }

        [HttpPost]
        public  async Task<ActionResult> Lista(FormCollection collection)
        {

            OrdenPagoViewModel OrdePagoVM = new OrdenPagoViewModel();
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("http://localhost:61341/api/OrdenPago/ListaOrdenPago/" + Int32.Parse(collection["Sucursal_ID"]));

            List<BEOrdenPago> lstOrdenPago = JsonConvert.DeserializeObject<List<BEOrdenPago>>(json);
            OrdePagoVM.ListaOrdenPago = lstOrdenPago;


            List<BESucursal> lstSucursal = new List<BESucursal>();

            lstSucursal = oblBanco.ConsultarSucursales(new BESucursal());

            OrdePagoVM.ListaSucursalCombo = lstSucursal.Select(e => new SucursalViewModel { Sucursal_ID = e.Sucursal_ID, Sucursal_Nombre = e.Sucursal_Nombre }).ToList();

                List<BEMoneda> lstMoneda = new List<BEMoneda>();

                lstMoneda = oblBanco.ConsultarMoneda(new BEMoneda());
           lstMoneda.Select(e => new MonedaViewModel { Moneda_ID = e.Moneda_ID, Moneda_Nombre = e.Moneda_Nombre }).ToList(); ;


           return View(OrdePagoVM);

        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
   
            OrdenPagoViewModel OrdenPagoVW = new OrdenPagoViewModel();
            List<BESucursal> lstSucursal = new List<BESucursal>();

            lstSucursal = oblBanco.ConsultarSucursales(new BESucursal());
            //veriicar
            OrdenPagoVW.ListaSucursalCombo = lstSucursal.Select(e => new SucursalViewModel { Sucursal_ID = e.Sucursal_ID, Sucursal_Nombre = e.Sucursal_Nombre }).ToList();

            List<BEMoneda> lstMoneda = new List<BEMoneda>();

            lstMoneda = oblBanco.ConsultarMoneda(new BEMoneda());
            //veriicar

            OrdenPagoVW.ListaMonedaCombo = lstMoneda.Select(e => new MonedaViewModel { Moneda_ID = e.Moneda_ID, Moneda_Nombre = e.Moneda_Nombre, Moneda_Abreviatura = e.Moneda_Abreviatura }).ToList(); ;

            List<BEEstadoOrden> lstEstadoOrden = new List<BEEstadoOrden>();

            lstEstadoOrden = oblBanco.ConsultarEstadoOrden(new BEEstadoOrden());
            //veriicar error
            OrdenPagoVW.ListaEstadoCombo = lstEstadoOrden.Select(e => new EstadoOrdendenViewModel { EstadoOrden_ID = e.EstadoOrden_ID, EstadoOrden_Nombre = e.EstadoOrden_Nombre }).ToList();

            return View(OrdenPagoVW);
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                List<BEOrdenPago> lstOrdenPago = new List<BEOrdenPago>();
                lstOrdenPago = oblBanco.RegistrarOrdenPago(new BEOrdenPago
                {
                    Sucursal_ID = Int32.Parse(collection["Sucursal_ID"]),

                    Moneda_ID = Int32.Parse(collection["Moneda_ID"]),
                    // Moneda_Abreviatura=collection["Moneda_Abreviatura"].ToString(),
                    EstadoOrden_ID = Int32.Parse(collection["EstadoOrden_ID"]),
                    OrdenPago_FechaPago = DateTime.Parse(collection["OrdenPago_FechaPago"]),
                    OrdenPago_Monto = Decimal.Parse(collection["OrdenPago_Monto"])
                });
                //verificar

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(OrdenPagoViewModel item)
        {
            List<BESucursal> lstSucursal = new List<BESucursal>();

            lstSucursal = oblBanco.ConsultarSucursales(new BESucursal());

            item.ListaSucursalCombo = lstSucursal.Select(e => new SucursalViewModel { Sucursal_ID = e.Sucursal_ID, Sucursal_Nombre = e.Sucursal_Nombre }).ToList();

            List<BEMoneda> lstMoneda = new List<BEMoneda>();
            lstMoneda = oblBanco.ConsultarMoneda(new BEMoneda());

            item.ListaMonedaCombo = lstMoneda.Select(e => new MonedaViewModel { Moneda_ID = e.Moneda_ID, Moneda_Abreviatura = e.Moneda_Abreviatura, Moneda_Nombre = e.Moneda_Nombre }).ToList(); ;

            List<BEEstadoOrden> lstEstadoOrden = new List<BEEstadoOrden>();
            lstEstadoOrden = oblBanco.ConsultarEstadoOrden(new BEEstadoOrden());


            item.ListaEstadoCombo = lstEstadoOrden.Select(e => new EstadoOrdendenViewModel { EstadoOrden_ID = e.EstadoOrden_ID, EstadoOrden_Nombre = e.EstadoOrden_Nombre }).ToList();

            return View(item);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(OrdenPagoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                List<BEOrdenPago> lstOrdenPago = new List<BEOrdenPago>();
                lstOrdenPago = oblBanco.ActualizarOrdenPago(new BEOrdenPago
                {

                    OrdenPago_ID = item.OrdenPago_ID,
                    Sucursal_ID = item.OrdenPago_ID,
                    OrdenPago_Monto = item.OrdenPago_Monto,
                    Moneda_ID = item.Moneda_ID,
                    EstadoOrden_ID = item.EstadoOrden_ID,
                    OrdenPago_FechaPago = item.OrdenPago_FechaPago
                });
                //if (respuesta.CodigoError == 0)

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(OrdenPagoViewModel item)
        {
            return View(item);
        }

        // POST: OrdenPago/Delete/5
        [HttpPost]
        public ActionResult Delete(OrdenPagoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                List<BEOrdenPago> lstOrdenPago = new List<BEOrdenPago>();
                lstOrdenPago = oblBanco.EliminarOrdenPago(new BEOrdenPago
                {
                    OrdenPago_ID = item.OrdenPago_ID
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

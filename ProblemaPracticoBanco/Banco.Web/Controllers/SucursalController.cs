using Banco.EntitadadesNegocio;
using Banco.LogicaNegocio;
using Banco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banco.Web.Controllers
{

    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {

            SucursalViewModel SucursalVW = new SucursalViewModel();
            List<BESucursal> lstSucursal = new List<BESucursal>();
            BLBanco oblBanco = new BLBanco();
            lstSucursal = oblBanco.ConsultarSucursales(new BESucursal());

            SucursalVW.ListaSucursal = lstSucursal;

            return View(SucursalVW);
        }

        // GET: Sucursal/Details/5
        public ActionResult Consulta()
        {
            BLBanco oblBanco = new BLBanco();
            SucursalViewModel SucursalVW = new SucursalViewModel();
            SucursalVW.ListaSucursal = new List<BESucursal>();
            List<BEBanco> lstSucursal = new List<BEBanco>();
            lstSucursal = oblBanco.ConsultarBanco(new BEBanco());

            SucursalVW.ListaBancoCombo = lstSucursal.Select(e => new BancoViewModel { Banco_ID = e.Banco_ID, Banco_Nombre = e.Banco_Nombre }).ToList();

            return View(SucursalVW);
        }

        [HttpPost]
        public ActionResult Consulta(FormCollection collection)
        {
            BLBanco oblBanco = new BLBanco();
            SucursalViewModel SucursalVW = new SucursalViewModel();
            List<BESucursal> lstSucursal = new List<BESucursal>();

            if (!string.IsNullOrEmpty(collection["Banco_ID"]))
            {
                lstSucursal = oblBanco.ConsultarSucursales(new BESucursal { Banco_ID = Int32.Parse(collection["Banco_ID"]) });

                SucursalVW.ListaSucursal = lstSucursal;
            }

            List<BEBanco> lstBanco = new List<BEBanco>();
            lstBanco = oblBanco.ConsultarBanco(new BEBanco());

            SucursalVW.ListaBancoCombo = lstBanco.Select(e => new BancoViewModel { Banco_ID = e.Banco_ID, Banco_Nombre = e.Banco_Nombre }).ToList();

            return View(SucursalVW);
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            BLBanco oblBanco = new BLBanco();
            SucursalViewModel SucursalVW = new SucursalViewModel();
            List<BEBanco> lstBanco = new List<BEBanco>();
            lstBanco = oblBanco.ConsultarBanco(new BEBanco());
            //Veri
            SucursalVW.ListaBancoCombo = lstBanco.Select(e => new BancoViewModel { Banco_ID = e.Banco_ID, Banco_Nombre = e.Banco_Nombre }).ToList();

            return View(SucursalVW);
        }

        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BLBanco oblBanco = new BLBanco();
                List<BESucursal> lstSucursal = new List<BESucursal>();
                lstSucursal = oblBanco.RegistrarSucursal(new BESucursal
                {
                    //Banco = new BEBanco() { Banco_ID = Int32.Parse(collection["Banco_ID"]) },
                    Banco_ID=Int32.Parse(collection["Banco_ID"]),
                    Sucursal_Nombre = collection["Sucursal_Nombre"],
                    Sucursal_Direccion = collection["Sucursal_Direccion"],
                  });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(SucursalViewModel item)
        {

            BLBanco oblBanco = new BLBanco();
            List<BEBanco> lstBanco = new List<BEBanco>();
            lstBanco = oblBanco.ConsultarBanco(new BEBanco());

            item.ListaBancoCombo = lstBanco.Select(e => new BancoViewModel { Banco_ID = e.Banco_ID, Banco_Nombre = e.Banco_Nombre }).ToList();

            return View(item);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(SucursalViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                BLBanco oblBanco = new BLBanco();
                List<BESucursal> lstSucursal = new List<BESucursal>();
                lstSucursal = oblBanco.ActualizarSucursal(new BESucursal
                {
                    Sucursal_ID = item.Sucursal_ID,
                   // Banco = new BEBanco() { Banco_ID = item.Banco.Banco_ID },
                    Banco_ID=item.Banco_ID,
                    Sucursal_Nombre = item.Sucursal_Nombre,
                    Sucursal_Direccion = item.Sucursal_Direccion,
                    Sucursal_FechaRegistro = item.Sucursal_FechaRegistro
                });
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(SucursalViewModel item)
        {
            return View(item);
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(SucursalViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BLBanco oblBanco = new BLBanco();
                List<BESucursal> lstSucursal = new List<BESucursal>();
                lstSucursal = oblBanco.EliminarSucursal(new BESucursal
                {
                    Sucursal_ID = item.Sucursal_ID
                });
                //if (respuesta.CodigoError == 0)
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
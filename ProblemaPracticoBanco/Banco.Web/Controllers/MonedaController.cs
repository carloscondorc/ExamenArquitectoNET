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
    public class MonedaController : Controller
    {
        // GET: Moneda
        public ActionResult Index()
        {
            MonedaViewModel BancoVW = new MonedaViewModel();
            List<BEMoneda> lstMoneda= new List<BEMoneda>();
            BLBanco oblBanco = new BLBanco();

            lstMoneda = oblBanco.ConsultarMoneda(new BEMoneda());

            BancoVW.ListaMoneda = lstMoneda;

            return View(BancoVW);
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BLBanco oblBanco = new BLBanco();
                List<BEMoneda> lstMoneda = new List<BEMoneda>();
                lstMoneda = oblBanco.RegistrarMoneda(new BEMoneda
                {
                    Moneda_Nombre = collection["Moneda_Nombre"],
                    Moneda_Abreviatura = collection["Moneda_Abreviatura"],
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(MonedaViewModel item)
        {
            return View(item);
        }

        // POST: Moneda/Edit/5
        [HttpPost]
        public ActionResult Edit(MonedaViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                BLBanco oblBanco = new BLBanco();
                List<BEMoneda> lstMoneda = new List<BEMoneda>();
                lstMoneda = oblBanco.ActualizarMoneda(new BEMoneda
                {
                    Moneda_ID = item.Moneda_ID,
                    Moneda_Nombre = item.Moneda_Nombre,
                    Moneda_Abreviatura = item.Moneda_Abreviatura,
                });
                //if (respuesta.CodigoError == 0)  

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Moneda/Delete/5
        public ActionResult Delete(MonedaViewModel item)
        {
            return View(item);
        }

        // POST: Moneda/Delete/5
        [HttpPost]
        public ActionResult Delete(MonedaViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BLBanco oblBanco = new BLBanco();
                List<BEMoneda> lstBanco = new List<BEMoneda>();
                lstBanco = oblBanco.EliminarMoneda(new BEMoneda
                {
                    Moneda_ID = item.Moneda_ID
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

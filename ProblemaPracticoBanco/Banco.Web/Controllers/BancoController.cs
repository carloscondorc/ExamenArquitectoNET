using Banco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banco.EntitadadesNegocio;
using Banco.LogicaNegocio;
namespace Banco.Web.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            
            BancoViewModel BancoVW = new BancoViewModel();
            List<BEBanco> lstBanco = new List<BEBanco>();
            BLBanco oblBanco = new BLBanco();

            lstBanco = oblBanco.ConsultarBanco(new BEBanco());

            BancoVW.ListaBanco = lstBanco;
   
            return View(BancoVW);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BLBanco oblBanco = new BLBanco();
                List<BEBanco> lstBanco = new List<BEBanco>();
                lstBanco = oblBanco.RegistrarBanco(new BEBanco
                {
                    Banco_Nombre = collection["Banco_Nombre"],
                    Banco_Direccion = collection["Banco_Direccion"],
                 });
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(BancoViewModel item)
        {
            return View(item);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(BancoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                BLBanco oblBanco = new BLBanco();
                List<BEBanco> lstBanco = new List<BEBanco>();
                lstBanco = oblBanco.ActualizarBanco(new BEBanco
                {
                    Banco_ID = item.Banco_ID,
                    Banco_Nombre= item.Banco_Nombre,
                    Banco_Direccion = item.Banco_Direccion,
                  });
                //if (respuesta.CodigoError == 0)  

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(BancoViewModel item)
        {
            return View(item);
        }

        // POST: Banco/Delete/5
        [HttpPost]
        public ActionResult Delete(BancoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BLBanco oblBanco = new BLBanco();
                List<BEBanco> lstBanco = new List<BEBanco>();
                lstBanco = oblBanco.EliminarBanco(new BEBanco
                {
                    Banco_ID = item.Banco_ID
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

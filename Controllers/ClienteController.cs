using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Manager_Empres_X.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client_Manager_Empres_X.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente(){id=129,Nombre_Completo="Juan Peres", dircciones = new List<Direccion>{new Direccion() { id=1,direccion="Sanches 50, Sonador, Bonao"} }},
            new Cliente(){id=234,Nombre_Completo="Maria Felix"},
            new Cliente(){id=665, Nombre_Completo="Juan Cena"}
        };
        // GET: ClienteController
        public ActionResult Index()
        {
            return View(Clientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View(Clientes.FirstOrDefault(a => a.id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(IFormCollection collection)
        {
            try
            {
                Direccion direccion = new Direccion()
                {
                    direccion = collection["direccion"]
                };
                int idCli = int.Parse(collection["idCliente"]);
                var cliente = Clientes.FirstOrDefault(a => a.id == idCli);
                direccion.id = cliente.dircciones.Count + 1;
                Clientes.FirstOrDefault(a => a.id == idCli).dircciones.Add(direccion);


                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult QuitarDireccion(int id, int idCliente)
        {
            var dir = Clientes.FirstOrDefault(a => a.id == idCliente).dircciones.FirstOrDefault(b=>b.id == id);
            Clientes.FirstOrDefault(a => a.id == idCliente).dircciones.Remove(dir);



            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    id = int.Parse(collection["id"]),
                    Nombre_Completo = collection["Nombre_Completo"]
                };
                Clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Clientes.FirstOrDefault(a => a.id == id));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Clientes.FirstOrDefault(a => a.id == id).Nombre_Completo = collection["Nombre_Completo"];
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

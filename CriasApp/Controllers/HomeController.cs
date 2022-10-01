using CriasApp.Models;
using CriasApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CriasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBCRIASContext _ContextDB;

        public HomeController(DBCRIASContext context)
        {
            _ContextDB = context;
        }

        public IActionResult Index()
        {

            List<Cria> listaCrias = _ContextDB.Cria.Include(p => p.oProveedor).ToList();

            return View(listaCrias);
        }


        [HttpGet]
        public IActionResult Cria_Detalle(int Id)
        {

            CriaViewModel criaViewModel = new CriaViewModel()
            {
                oCria = new Cria(),
                oListaProveedor = _ContextDB.Proveedores.Select(proveedor => new SelectListItem()
                {
                    Text = proveedor.Nombre,
                    Value = proveedor.Id.ToString()
                }).ToList()
            };

            if (Id != 0)
            {
                criaViewModel.oCria = _ContextDB.Cria.Find(Id);
            }

            return View(criaViewModel);
        }


        //Guarda crias en bd
        [HttpPost]
        public IActionResult Cria_Detalle(CriaViewModel criaViewModel)
        {

            if (criaViewModel.oCria.Id == 0)
            {
                _ContextDB.Cria.Add(criaViewModel.oCria);
            }
            else
            {
                _ContextDB.Cria.Update(criaViewModel.oCria);    
            }

            _ContextDB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }




        [HttpGet]
        public IActionResult Eliminar(int Id)
        {

            Cria oCria = _ContextDB.Cria.Include(p => p.oProveedor).Where(e => e.Id == Id).FirstOrDefault();
          
            return View(oCria);
        }

        [HttpPost]
        public IActionResult Eliminar(Cria oCria)
        {

            _ContextDB.Cria.Remove(oCria);
            _ContextDB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Sensores(int Id)
        {
            CriaViewModel criaViewModel = new CriaViewModel()
            {
                oCria = new Cria(),
                oListaProveedor = _ContextDB.Proveedores.Select(proveedor => new SelectListItem()
                {
                    Text = proveedor.Nombre,
                    Value = proveedor.Id.ToString()
                }).ToList()
            };




            if (Id != 0)
            {
                Sensores oSensores = _ContextDB.Sensores.Where(e => e.IdCria == Id).OrderBy(p => p.Id).LastOrDefault();
                criaViewModel.oCria = _ContextDB.Cria.Find(Id);
                criaViewModel.oSensores = oSensores;

                if (oSensores == null)
                {
                    Sensores sensores = new Sensores() { Temperatura = 0 };
                    criaViewModel.oSensores = sensores;
                }

                if (criaViewModel.oSensores.Temperatura >= 37.5 && criaViewModel.oSensores.Temperatura <= 39.5  )
                {
                    criaViewModel.oCria.Clasificacion = "Cria saludable";
                }
                else
                {
                    criaViewModel.oCria.Clasificacion = "Cria por enfermar";
                }

            }

           

            return View(criaViewModel);


        }


        //Guarda crias en bd
        [HttpPost]
        public IActionResult Sensores( CriaViewModel criaViewModel)
        {

            if (criaViewModel.oSensores.Temperatura >= 37.5 && criaViewModel.oSensores.Temperatura <= 39.5)
            {
                criaViewModel.oCria.Clasificacion = "Cria saludable";
                
            }
            else
            {
                ViewBag.Clasificacion = "Cria por enfermar";
            }



            criaViewModel.oSensores.IdCria = criaViewModel.oCria.Id;
            _ContextDB.Sensores.Update(criaViewModel.oSensores);


            
            




            _ContextDB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
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
        public IActionResult Cria_Detalle()
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

            _ContextDB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
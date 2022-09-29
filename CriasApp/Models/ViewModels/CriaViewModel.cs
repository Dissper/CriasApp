using Microsoft.AspNetCore.Mvc.Rendering;

namespace CriasApp.Models.ViewModels
{
    public class CriaViewModel
    {

        public Cria oCria { get; set; }
        public List<SelectListItem> oListaProveedor { get; set; }

        

    }
}

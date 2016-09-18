using Microsoft.AspNetCore.Mvc;
using app.Data;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {   
            return View(PokemonProvider.Instance.GetAll);
        }
    }
}

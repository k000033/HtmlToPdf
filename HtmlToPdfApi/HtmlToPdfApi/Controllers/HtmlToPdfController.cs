using Microsoft.AspNetCore.Mvc;

namespace HtmlToPdfApi.Controllers
{
    public class HtmlToPdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

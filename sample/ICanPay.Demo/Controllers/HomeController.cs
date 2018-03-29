using ICanPay.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ICanPay.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webmvc.Models;

namespace webmvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "(Default Space Web-App) Value from Catalog-microservice: ";

            // Use HeaderPropagatingHttpClient instead of HttpClient so we can propagate
            // headers in the incoming request to any outgoing requests

            //using (var client = new HeaderPropagatingHttpClient(this.Request))
            //{
            //    // Call *catalog*, and display its response in the page
            //    var response = await client.GetAsync("http://catalog/api/values/1");
            //    ViewData["Message"] += " ---> " + await response.Content.ReadAsStringAsync();
            //}

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

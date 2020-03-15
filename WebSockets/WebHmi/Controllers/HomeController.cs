using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHmi.Models;

namespace WebHmi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Read()
        {
            return View();
        }


        public IActionResult Write()
        {
            return View();
        }

        public IActionResult Call()
        {
            return View();
        }

        public IActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Invoke(string secret)
        {
            try
            {
                string input = await new StreamReader(Request.Body).ReadToEndAsync();

                StringContent content = new StringContent(input);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpClient client = new HttpClient();
                var response = await client.PostAsync("https://prototyping.opcfoundation.org:62540", content);

                if (!response.IsSuccessStatusCode)
                {
                    return new StatusCodeResult((int)response.StatusCode);
                }

                var output = await response.Content.ReadAsStringAsync();
                return Content(output, "application/json");
            }
            catch (Exception e)
            {
                return Content($"{{\"ProxyError\":\"{e}\"}}", "application/json");
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

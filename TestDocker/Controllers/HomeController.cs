using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using TestDocker.Models;

namespace TestDocker.Controllers
{
    public class IdName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            Console.WriteLine("Calling " + id);
            try
            {
                return View(new IdName{Name = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error", e);
            }
        }

        public async Task<IActionResult> Privacy()
        {
            Console.WriteLine("Calling test-docker-service");
            var url = "http://test-docker-service/";
            await url.GetAsync();
            
            Console.WriteLine("Calling test-docker-service success");
            
            return View();
        }
    }
}
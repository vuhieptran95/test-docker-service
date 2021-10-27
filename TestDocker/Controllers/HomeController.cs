using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
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
            _logger.LogInformation("Calling " + id);
            try
            {
                return View(new IdName { Name = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return View("Error", e);
            }
        }

        public async Task<IActionResult> Privacy([FromQuery]string url)
        {
            try
            {
                _logger.LogInformation("Start get: " + url);
                var res = await url.AllowAnyHttpStatus().GetStringAsync();
                _logger.LogInformation("Result: " + res);
                return View("Privacy",res);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
        
        // public async Task<IActionResult> Privacy()
        // {
        //     return View();
        // }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;
using DataLayer;
using DataLayer.Entites;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core.Controllers
{
    public class HomeController : Controller
    {
        private EFDBContext _context;

        public HomeController(EFDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Directory> directories = _context.Directories.Include(x => x.Materials).ToList();
            return View(directories);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

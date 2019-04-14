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
using BuissnesLayer;
using PresentationLayer;

namespace asp_net_core.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        private EFDBContext _context;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }
        public IActionResult Index()
        {
            // List<Directory> _directories = _context.Directories.Include(x => x.Materials).ToList();
            List<Directory> _directories = _dataManager.Derictorys.GetAllDirectories(true).ToList();
            return View(_directories);
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

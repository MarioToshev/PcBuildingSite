using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Services;

namespace PcBuildingSite.Controllers
{
    public class RamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RamController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddRam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRam(RamDto ram)
        {
            if (ModelState.IsValid)
            {
                componentService.CreateRam(ram);
                return RedirectToAction(nameof(AddRam));
            }
            return View();
        }

    }
}

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
    public class PcStorageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public PcStorageController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddPcStorage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPcStorage(PcStorageDto storage)
        {
            if (ModelState.IsValid)
            {
                componentService.CreatePcStorage(storage);
                return RedirectToAction(nameof(Index));
            }
            return View(AddPcStorage());
        }
    }
}
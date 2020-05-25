using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using PcBuildingSite.Models;
using PcBuildingSite.Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using PcBuildingSite.Services;
using PcBuildingSite.Data.Models.Component;

namespace PcBuildingSite.Controllers
{
    public class GPUController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public GPUController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AddGPU()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGPU(GpuDto gpu)
        {
            if (ModelState.IsValid)
            {
                this.componentService.CreateGPU(gpu);
                return RedirectToAction(nameof(AddGPU));
            }
            return View(gpu);
        }
    }
}
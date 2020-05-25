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
    public class CpuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CpuController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddCpu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCpu(CpuDto cpu)
        {
            if (ModelState.IsValid)
            {
                componentService.CreateCPU(cpu);
                return RedirectToAction(nameof(AddCpu));
            }
            return View();
        }

    }
}
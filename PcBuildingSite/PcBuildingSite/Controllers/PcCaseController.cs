using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Models;
using PcBuildingSite.Services;

namespace PcBuildingSite.Controllers
{
    public class PcCaseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public PcCaseController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddPcCase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPcCase(PcCaseDto pcCase)
        {
            if (ModelState.IsValid)
            {
                componentService.CreatePcCase(pcCase);
                return RedirectToAction(nameof(AddPcCase));
            }
            else
            {
                return View("The component exists");
            }
            
        }
    }
}
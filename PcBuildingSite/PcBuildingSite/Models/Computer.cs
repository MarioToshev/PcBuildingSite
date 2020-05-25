using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Models.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Storage = PcBuildingSite.Models.Components.Storage;

namespace PcBuildingSite.Models
{
    public class Computer
    {
        private CPU cpu;
        private Gpu gpu;
        private RAM ram;
        private Motherboard motherboard;
      
        private PSU psu;
        private PcCase Case;

        public Computer(CPU cpu, Gpu gpu, RAM ram, Motherboard motherboard,  PSU psu, PcCase case1)
        {
            Cpu = cpu;
            Gpu = gpu;
            Ram = ram;
            Motherboard = motherboard;
           
            Psu = psu;
            Case1 = case1;
        }

        public CPU Cpu { get => cpu; set => cpu = value; }
        public Gpu Gpu { get => gpu; set => gpu = value; }
        public RAM Ram { get => ram; set => ram = value; }
        public Motherboard Motherboard { get => motherboard; set => motherboard = value; }
        
        public PSU Psu { get => psu; set => psu = value; }
        public PcCase Case1 { get => Case; set => Case = value; }

        [Required]
        [Display(Name = "Case")]
        public string dCase { get; set; }
        [Required]
        [Display(Name = "CPU")]
        public string dCPU { get; set; }
        [Required]
        [Display(Name = "GPU")]
        public string dGPU { get; set; }
        [Required]
        [Display(Name = "RAM")]
        public string dRAM { get; set; }
        [Required]
        [Display(Name = "Storage")]
        public string dStorage { get; set; }
        [Required]
        [Display(Name = "Motherboard")]
        public string dMotherboard { get; set; }
        [Required]
        [Display(Name = "PSU")]
        public string dPSU { get; set; }
    }
}
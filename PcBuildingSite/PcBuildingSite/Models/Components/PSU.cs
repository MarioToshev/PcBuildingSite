using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Models.Components
{
    public class PSU
    {
        private string model;
        private double powerEfficiency;
        private double price;

        public string Model { get => model; set => model = value; }
        public double PowerEfficiency { get => powerEfficiency; set => powerEfficiency = value; }
        public double Price { get => price; set => price = value; }
    }
}

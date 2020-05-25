using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Models.Components
{
    public class HDD : Storage
    {
        private string model;
        private double memorysize;
        private double price;

        public HDD(string model, double memorysize, double price) : base(model, memorysize, price)
        {
            Model = model;
            Memorysize = memorysize;
            Price = price;   
        }


        public string Model { get => model; set => model = value; }
        public double Memorysize { get => memorysize; set => memorysize = value; }
        public double Price { get => price; set => price = value; }

    }
}

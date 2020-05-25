using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Models.Components
{
    public class SSD : Storage
    {
        private string model;
        private double memorysize;
        private double price;
        private double size;



        public SSD(string model, double memorysize, double price) : base(model, memorysize, price)
        {
            Model = model;
            Memorysize = memorysize;
            Price = price;
        }


        public string Model { get => model; set => model = value; }
        public double Memorysize { get => memorysize; set => memorysize = value; }
        public double Price { get => price; set => price = value; }

        //public double Size { get => size; set => size = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopsCLI
{
    internal class Laptop
    {
        public Category Category { get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public int RAM { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }

        public Laptop(string row)
        {
            var data = row.Split(";");
            Category = new(int.Parse(data[0]), data[1]);
            CPU = data[2];
            Manufacturer = new(int.Parse(data[3]), data[4]);
            Model = data[5];
            OS = data[6];
            Price = double.Parse(data[7]);
            RAM = int.Parse(data[8]);
            Screen = data[9];
            Storage = data[10];
        }

        public override string? ToString() => $"{Category.CategoryName} | {Manufacturer.ManufacturerName} {Model} | {OS}";
    }
}

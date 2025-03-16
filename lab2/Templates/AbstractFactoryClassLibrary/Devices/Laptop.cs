using AbstractFabricClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabricClassLibrary.Devices
{
    public class Laptop : IDevice
    {
        private string _brand;

        public Laptop(string brand)
        {
            _brand = brand;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_brand} Laptop created.");
        }
    }
}

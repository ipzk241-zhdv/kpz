using AbstractFabricClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabricClassLibrary.Devices
{
    public class Smartphone : IDevice
    {
        private string _brand;

        public Smartphone(string brand)
        {
            _brand = brand;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_brand} Smartphone created.");
        }
    }
}

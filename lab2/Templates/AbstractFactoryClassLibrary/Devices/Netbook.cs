using AbstractFabricClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabricClassLibrary.Devices
{
    public class Netbook : IDevice
    {
        private string _brand;

        public Netbook(string brand)
        {
            _brand = brand;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_brand} Netbook created.");
        }
    }
}

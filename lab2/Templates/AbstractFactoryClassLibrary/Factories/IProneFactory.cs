using AbstractFabricClassLibrary.Devices;
using AbstractFabricClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabricClassLibrary.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public IDevice CreateLaptop() => new Laptop("IProne");
        public IDevice CreateNetbook() => new Netbook("IProne");
        public IDevice CreateEBook() => new EBook("IProne");
        public IDevice CreateSmartphone() => new Smartphone("IProne");
    }
}

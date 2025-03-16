using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderClassList.Models
{
    public class Character
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Class { get; set; }
        public string SpecialAction { get; set; }
        public string Ultimate { get; set; }

        public float Height { get; set; }
        public string BodyType { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothes { get; set; }

        public List<string> Inventory { get; set; } = new();
        public List<string> Deeds { get; set; } = new();
    }
}

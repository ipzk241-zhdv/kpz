namespace PrototypeClassLibrary
{
    public class Virus : IVirus
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }

        public List<Virus> Children { get; set; } = new List<Virus>();

        public Virus(string name, string species, float weight, int age)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public IVirus Clone()
        {
            // Глибоке копіювання
            var clone = new Virus(Name, Species, Weight, Age);
            foreach (var child in Children)
            {
                clone.AddChild((Virus)child.Clone());
            }
            return clone;
        }

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent} {Name} ({Species}) - Age: {Age}, Weight: {Weight}g");
            foreach (var child in Children)
            {
                child.Print(indent + "  ");
            }
        }
    }
}

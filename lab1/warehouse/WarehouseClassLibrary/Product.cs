namespace WarehouseClassLibrary
{
    public enum Category
    {
        Electronics,
        Food,
        Clothing,
        Home,
        Other
    }

    public class Product
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public Category ProductCategory { get; private set; }
        public int Quantity { get; private set; }

        public Dictionary<int, Money[]> SalesRevenue { get; private set; } = new();
        public Dictionary<int, int[]> UnitsSold { get; private set; } = new();

        public Product(string name, Money price, Category category, int quantity)
        {
            Name = name;
            Price = price;
            ProductCategory = category;
            Quantity = quantity;
        }

        public void SetPrice(Money newPrice)
        {
            Price = newPrice;
        }

        public void ReduceStock(int amount, int year, int month)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
                if (!SalesRevenue.ContainsKey(year))
                {
                    SalesRevenue[year] = Enumerable.Range(0, 12)
                        .Select(_ => new Hryvnia(0, 0))
                        .ToArray();
                    UnitsSold[year] = new int[12];
                }
                Money revenueToAdd = Price.ConvertTo("UAH").Multiply(amount);
                SalesRevenue[year][month - 1] = SalesRevenue[year][month - 1].Add(revenueToAdd);
                UnitsSold[year][month - 1] += amount;
            }
            else
            {
                throw new InvalidOperationException("Недостатньо товару на складі.");
            }
        }

        public void ChangeQuantity(int amount)
        {
            if (amount > 0)
            {
                Quantity += amount;
                return;
            }
            else if (amount < 0 && Quantity >= Math.Abs(amount))
            {
                Quantity += amount;
            }
            else
            {
                throw new InvalidOperationException("Недостатньо товару на складі.");
            }
        }
    }
}

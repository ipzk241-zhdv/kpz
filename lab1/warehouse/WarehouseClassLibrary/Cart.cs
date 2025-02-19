namespace WarehouseClassLibrary
{
    public class Cart
    {
        private Dictionary<Product, int> items = new();

        public void AddToCart(Product product, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity cant be a 0");
            }
            if (items.ContainsKey(product))
                items[product] += quantity;
            else
                items[product] = quantity;
        }

        public void RemoveFromCart(Product product)
        {
            items.Remove(product);
        }

        public IEnumerable<(Product, int)> GetCartItems()
        {
            return items.Select(i => (i.Key, i.Value));
        }

        public Money CalculateTotal(string targetCurrency = "UAH")
        {
            Money total = targetCurrency switch
            {
                "USD" => new Dollar(0, 0),
                "EUR" => new Euro(0, 0),
                _ => new Hryvnia(0, 0)
            };

            foreach (var item in items)
            {
                Money priceConverted = item.Key.Price.ConvertTo(targetCurrency);
                Money productTotal = priceConverted.Multiply(item.Value);
                total = total.Add(productTotal);
            }

            return total;
        }

        public void Purchase(Warehouse warehouse, int year, int month)
        {
            foreach (var (product, quantity) in items)
            {
                if (product.Quantity < quantity)
                {
                    Console.WriteLine($"Not enough stock for {product.Name}.");
                    return;
                }
                product.ReduceStock(quantity, year, month);
            }
            items.Clear();
        }
    }
}

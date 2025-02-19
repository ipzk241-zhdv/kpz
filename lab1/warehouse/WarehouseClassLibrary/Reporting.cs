namespace WarehouseClassLibrary
{
    public class Reporting
    {
        private readonly string[] months = new string[]
        {
            "січень", "лютий", "березень", "квітень", "травень", "червень",
            "липень", "серпень", "вересень", "жовтень", "листопад", "грудень"
        };

        public void GenerateInventoryReport(Warehouse warehouse)
        {
            Console.WriteLine("Inventory Report:");
            foreach (var product in warehouse.GetProducts())
            {
                Console.WriteLine($"Product: {product.Name}, Category: {product.ProductCategory}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        public void GenerateProductSalesReport(Warehouse warehouse, string targetCurrency = "UAH")
        {
            foreach (var product in warehouse.GetProducts())
            {
                Console.WriteLine($"{product.Name}:");
                if (product.SalesRevenue.Count == 0)
                {
                    Console.WriteLine("No sales data available.");
                }
                else
                {
                    var yearReports = new List<string>();
                    foreach (var kvp in product.SalesRevenue.OrderBy(k => k.Key))
                    {
                        int year = kvp.Key;
                        Money[] revenueArr = kvp.Value;
                        var monthReports = new List<string>();
                        for (int i = 0; i < revenueArr.Length; i++)
                        {
                            if (!(revenueArr[i].WholePart == 0 && revenueArr[i].Cents == 0))
                            {
                                Money converted = revenueArr[i].ConvertTo(targetCurrency);
                                monthReports.Add($"\n  -- {months[i]}: {converted.WholePart}.{converted.Cents} {targetCurrency}");
                            }
                        }
                        string monthsString = monthReports.Count > 0 ? string.Join(", ", monthReports) : "";
                        yearReports.Add($" - {year}: {monthsString}\n-----------\n");
                    }
                    string report = string.Join("", yearReports);
                    Console.WriteLine(report);
                }
            }
        }

        public void GenerateOverallRevenueReport(Warehouse warehouse, string targetCurrency = "UAH", Category? targetCategory = null)
        {
            Dictionary<int, Money[]> overallRevenue = new Dictionary<int, Money[]>();

            foreach (var product in warehouse.GetProducts())
            {
                if (targetCategory.HasValue && product.ProductCategory != targetCategory.Value)
                {
                    continue;
                }

                foreach (var kvp in product.SalesRevenue)
                {
                    int year = kvp.Key;
                    Money[] revenueArr = kvp.Value;
                    if (!overallRevenue.ContainsKey(year))
                    {
                        overallRevenue[year] = Enumerable.Range(0, 12)
                            .Select<int, Money>(_ => targetCurrency switch
                            {
                                "USD" => new Dollar(0, 0),
                                "EUR" => new Euro(0, 0),
                                _ => new Hryvnia(0, 0)
                            })
                            .ToArray();
                    }

                    for (int i = 0; i < revenueArr.Length; i++)
                    {
                        Money convertedRevenue = revenueArr[i].ConvertTo(targetCurrency);
                        overallRevenue[year][i] = overallRevenue[year][i].Add(convertedRevenue);
                    }
                }
            }

            var yearReports = new List<string>();
            foreach (var kvp in overallRevenue.OrderBy(k => k.Key))
            {
                int year = kvp.Key;
                Money[] moneyArr = kvp.Value;
                var monthReports = new List<string>();
                for (int i = 0; i < moneyArr.Length; i++)
                {
                    if (!(moneyArr[i].WholePart == 0 && moneyArr[i].Cents == 0))
                    {
                        monthReports.Add($"\n   -- {months[i]}: {moneyArr[i].WholePart}.{moneyArr[i].Cents:D2} {targetCurrency}");
                    }
                }
                string monthsString = monthReports.Count > 0 ? string.Join(", ", monthReports) : "";
                yearReports.Add($" - {year}: {monthsString}\n");
            }
            string reportFinal = string.Join("", yearReports);
            Console.WriteLine(reportFinal);
        }
    }
}
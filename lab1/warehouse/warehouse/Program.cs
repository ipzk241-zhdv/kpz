using static System.Console;
using WarehouseClassLibrary;
using System.Text;

class Program
{
    static void Main()
    {
        OutputEncoding = Encoding.UTF8;
        // Створення складу
        Warehouse warehouse = new Warehouse();
        Reporting reporting = new Reporting();
        Cart cart = new Cart();

        // Створення товарів з різними валютами, категоріями та кількістю
        Product laptop = new Product("Laptop", new Dollar(1000, 0), Category.Electronics, 250);
        Product apple = new Product("Apple", new Hryvnia(30, 50), Category.Food, 100);
        Product tshirt = new Product("T-Shirt", new Euro(20, 0), Category.Clothing, 50);

        // Додавання товарів до складу
        warehouse.AddProduct(laptop);
        warehouse.AddProduct(apple);
        warehouse.AddProduct(tshirt);

        // Генерація звіту по інвентарю
        WriteLine("\n--- Inventory Report ---");
        reporting.GenerateInventoryReport(warehouse);

        // Оновлення ціни
        tshirt.SetPrice(new Hryvnia(80, 25));
        laptop.SetPrice(new Dollar(900, 0));
        WriteLine($"\nОновлено ціни для\n -{laptop.Name}: {laptop.Price}\n -{tshirt.Name}: {tshirt.Price}");

        // "Cписання" та додавання товару
        apple.ChangeQuantity(-30);
        tshirt.ChangeQuantity(10);
        WriteLine($"\nЗміна кількості товару для\n -{apple.Name}: {apple.Quantity}\n -{tshirt.Name}: {tshirt.Quantity}");

        // Генерація звіту по інвентарю
        WriteLine("\n--- Inventory Report ---");
        reporting.GenerateInventoryReport(warehouse);

        // Купівля товарів
        for (int i = 1; i < 13; i++)
        {
            Random r = new Random();
            cart.AddToCart(laptop, r.Next(1, 5));
            cart.AddToCart(apple, r.Next(1,3));
            cart.Purchase(warehouse, 2025, i);
        }

        cart.AddToCart(laptop, 3);
        cart.AddToCart(apple, 2);
        cart.Purchase(warehouse, 2024, 1);

        WriteLine("\nБуло купленно деяку кількість товарів laptop та apple");

        // Генерація звіту по інвентарю
        WriteLine("\n--- Inventory Report ---");
        reporting.GenerateInventoryReport(warehouse);

        // Генерація звіту по продажу продуктів з розбивкою по місяцях
        WriteLine("\n--- Product Sales by month Report ---");
        reporting.GenerateProductSalesReport(warehouse, "USD");

        // Генерація загального звіту по виручці з розбивкою по місяцях
        WriteLine("\n--- Overall Revenue in USD by month Report ---");
        reporting.GenerateOverallRevenueReport(warehouse, "USD");

        // Генерація загального звіту по виручці з розбивкою по місяцях з вказаною категорією
        WriteLine("\n--- Overall Revenue in UAH by month by category Electronics Report ---");
        reporting.GenerateOverallRevenueReport(warehouse, "UAH", Category.Electronics);
    }
}


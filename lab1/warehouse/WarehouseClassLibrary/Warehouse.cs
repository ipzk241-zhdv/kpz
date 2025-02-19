namespace WarehouseClassLibrary
{
    public class Warehouse
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}

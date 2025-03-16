namespace FabricClassList
{
    public class WebSite
    {
        public Subscription PurchaseSubscription(SubscriptionFactory factory)
        {
            Console.WriteLine("Purchasing subscription via Website...");
            return factory.CreateSubscription();
        }
    }

    public class MobileApp
    {
        public Subscription PurchaseSubscription(SubscriptionFactory factory)
        {
            Console.WriteLine("Purchasing subscription via Mobile App...");
            return factory.CreateSubscription();
        }
    }

    public class ManagerCall
    {
        public Subscription PurchaseSubscription(SubscriptionFactory factory)
        {
            Console.WriteLine("Purchasing subscription via Manager Call...");
            return factory.CreateSubscription();
        }
    }
}

using FabricClassList;
using AbstractFabricClassLibrary.Interfaces;
using AbstractFabricClassLibrary.Factories;
using SingletonClassLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("------- Fabric -------");

        SubscriptionFactory domesticFactory = new DomesticSubscriptionFactory();
        SubscriptionFactory educationalFactory = new EducationalSubscriptionFactory();
        SubscriptionFactory premiumFactory = new PremiumSubscriptionFactory();

        WebSite website = new WebSite();
        MobileApp mobileApp = new MobileApp();
        ManagerCall managerCall = new ManagerCall();

        Subscription sub1 = website.PurchaseSubscription(domesticFactory);
        sub1.ShowDetails();

        Subscription sub2 = mobileApp.PurchaseSubscription(educationalFactory);
        sub2.ShowDetails();

        Subscription sub3 = managerCall.PurchaseSubscription(premiumFactory);
        sub3.ShowDetails();

        Console.WriteLine("------- Abstract Fabric -------");

        ShowDevices(new IProneFactory());
        ShowDevices(new KiaomiFactory());
        ShowDevices(new BalaxyFactory());

        Console.WriteLine("\n\n------- Singletone -------");
        
        // Створюємо кілька потоків, що намагаються отримати екземпляр
        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            int userId = i + 1;
            tasks[i] = Task.Run(() =>
            {
                Authenticator auth = Authenticator.Instance;
                auth.Authenticate($"User{userId}");
            });
        }

        Task.WaitAll(tasks);

        // Додатково перевіримо, що об'єкти рівні
        var a1 = Authenticator.Instance;
        var a2 = Authenticator.Instance;
        Console.WriteLine($"a1 == a2: {ReferenceEquals(a1, a2)}");
    }

    static void ShowDevices(IDeviceFactory factory)
    {
        Console.WriteLine("\n=== Creating Devices ===");

        IDevice laptop = factory.CreateLaptop();
        IDevice netbook = factory.CreateNetbook();
        IDevice ebook = factory.CreateEBook();
        IDevice smartphone = factory.CreateSmartphone();

        laptop.ShowInfo();
        netbook.ShowInfo();
        ebook.ShowInfo();
        smartphone.ShowInfo();
    }

}

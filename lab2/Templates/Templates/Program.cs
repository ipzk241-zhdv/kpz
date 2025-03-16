using FabricClassList;
using AbstractFabricClassLibrary.Interfaces;
using AbstractFabricClassLibrary.Factories;

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

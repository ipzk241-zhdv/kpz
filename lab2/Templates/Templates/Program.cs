using FabricClassList;
using AbstractFabricClassLibrary.Interfaces;
using AbstractFabricClassLibrary.Factories;
using SingletonClassLibrary;
using PrototypeClassLibrary;
using BuilderClassList.Builders;
using BuilderClassList.Director;
using BuilderClassList.Models;

class Program
{
    static void Main()
    {
        FabricDemo();
        AbstractFabricDemo();
        SingletoneDemo();
        PrototypeDemo();
        BuilderDemo();
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

    static void FabricDemo()
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
    }

    static void AbstractFabricDemo()
    {
        Console.WriteLine("------- Abstract Fabric -------");

        ShowDevices(new IProneFactory());
        ShowDevices(new KiaomiFactory());
        ShowDevices(new BalaxyFactory());
    }

    static void SingletoneDemo()
    {
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

    static void PrototypeDemo()
    {
        Console.WriteLine("\n\n------- Prototype -------");
        // Створюємо 3 покоління вірусів
        Virus parent = new Virus("Alpha", "Corona", 0.5f, 1);
        Virus child1 = new Virus("Beta", "Corona", 0.3f, 1);
        Virus child2 = new Virus("Gamma", "Corona", 0.2f, 1);

        parent.AddChild(child1);
        parent.AddChild(child2);

        Virus grandchild1 = new Virus("Delta", "Corona", 0.1f, 1);
        child1.AddChild(grandchild1);

        Console.WriteLine("\nOriginal Virus Family:");
        parent.Print();

        // Клонуємо
        Virus cloned = (Virus)parent.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        cloned.Print();

        // Підтвердження, що це різні обʼєкти:
        Console.WriteLine($"\nOriginal == Clone: {ReferenceEquals(parent, cloned)}");
        Console.WriteLine($"Original.Child[0] == Clone.Child[0]: {ReferenceEquals(parent.Children[0], cloned.Children[0])}");
    }

    static void BuilderDemo()
    {
        var director = new CharacterDirector();

        var heroBuilder = new HeroBuilder();
        director.ConstructBasicHero(heroBuilder);
        var hero = heroBuilder
            .AddGoodDeed("Killed his brothers")
            .AddGoodDeed("Defeated the Kain")
            .Build();

        var enemyBuilder = new EnemyBuilder();
        director.ConstructBasicEnemy(enemyBuilder);
        var enemy = enemyBuilder
            .AddEvilDeed("Served to Edler God")
            .AddEvilDeed("Stole the time")
            .Build();

        PrintCharacter(hero);
        Console.WriteLine();
        PrintCharacter(enemy);
    }

    static void PrintCharacter(Character character)
    {
        Console.WriteLine($"{character.Role}: {character.Name} aka {character.Nickname}");
        Console.WriteLine($"Class: {character.Class}");
        Console.WriteLine($"Special: {character.SpecialAction}");
        Console.WriteLine($"Ultimate: {character.Ultimate}");
        Console.WriteLine($"Height: {character.Height}");
        Console.WriteLine($"Body: {character.BodyType}");
        Console.WriteLine($"Hair: {character.HairColor}, Eyes: {character.EyeColor}");
        Console.WriteLine($"Clothes: {character.Clothes}");
        Console.WriteLine($"Inventory: {string.Join(", ", character.Inventory)}");
        Console.WriteLine($"Deeds: {string.Join("; ", character.Deeds)}");
    }
}

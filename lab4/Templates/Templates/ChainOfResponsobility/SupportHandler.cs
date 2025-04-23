using System;

abstract class SupportHandler
{
    protected SupportHandler next;

    public SupportHandler SetNext(SupportHandler next)
    {
        this.next = next;
        return next;
    }

    public abstract bool Handle();
}

class MainMenuHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.WriteLine("\n[Головне меню]");
        Console.WriteLine("1. Проблеми з Інтернетом");
        Console.WriteLine("2. Проблеми з оплатою");
        Console.WriteLine("3. Інші питання");

        Console.Write("Ваш вибір: ");
        var input = Console.ReadLine();

        if (input == "2")
        {
            Console.WriteLine("Передаємо до Білінгової підтримки... Підтримка завершена.");
            return true;
        }

        return next?.Handle() ?? false;
    }
}

class TechnicalMenuHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.WriteLine("\n[Технічна підтримка]");
        Console.WriteLine("1. Wi-Fi не працює");
        Console.WriteLine("2. Повільне з'єднання");
        Console.WriteLine("3. Немає сигналу");

        Console.Write("Ваш вибір: ");
        var input = Console.ReadLine();

        if (input == "1")
        {
            Console.WriteLine("Спробуйте перезавантажити маршрутизатор. Підтримка завершена.");
            return true;
        }

        return next?.Handle() ?? false;
    }
}

class ConnectionTypeHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.WriteLine("\n[Тип з'єднання]");
        Console.WriteLine("1. Кабельне");
        Console.WriteLine("2. Мобільне");
        Console.WriteLine("3. Супутникове");

        Console.Write("Ваш вибір: ");
        var input = Console.ReadLine();

        if (input == "3")
        {
            Console.WriteLine("Для супутникового з'єднання зверніться до спеціаліста. Підтримка завершена.");
            return true;
        }

        return next?.Handle() ?? false;
    }
}

class DetailMenuHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.WriteLine("\n[Деталі проблеми]");
        Console.WriteLine("1. Проблема виникає періодично");
        Console.WriteLine("2. Проблема постійна");
        Console.WriteLine("3. Проблема з новим обладнанням");

        Console.Write("Ваш вибір: ");
        var input = Console.ReadLine();

        if (input == "2")
        {
            Console.WriteLine("Це серйозна проблема. Передаємо до експерта...");
            return next?.Handle() ?? false;
        }

        return next?.Handle() ?? false;
    }
}

class FinalSupportHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.WriteLine("\n[З’єднання з експертом]");
        Console.WriteLine("Вас буде з’єднано з оператором. Зачекайте на лінії...");
        return true;
    }
}
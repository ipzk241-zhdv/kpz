using System;

class SupportSystem
{
    private readonly SupportHandler main = new MainMenuHandler();
    private readonly SupportHandler tech = new TechnicalMenuHandler();
    private readonly SupportHandler conn = new ConnectionTypeHandler();
    private readonly SupportHandler detail = new DetailMenuHandler();
    private readonly SupportHandler expert = new FinalSupportHandler();
    
    public SupportSystem()
    {
        main.SetNext(tech).SetNext(conn).SetNext(detail).SetNext(expert);
    }

    public void Start()
    {
        bool resolved = false;
        while (!resolved)
        {
            resolved = main.Handle();

            if (!resolved)
            {
                Console.WriteLine("\nПовертаємося до початку...\n");
            }
        }
    }
}
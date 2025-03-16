namespace FabricClassList
{
    public abstract class Subscription
    {
        public abstract string Name { get; }
        public abstract decimal MonthlyFee { get; }
        public abstract int MinPeriod { get; }
        public abstract List<string> Features { get; }

        public void ShowDetails()
        {
            Console.WriteLine($"Subscription: {Name}");
            Console.WriteLine($"Monthly Fee: {MonthlyFee} USD");
            Console.WriteLine($"Minimum Period: {MinPeriod} months");
            Console.WriteLine("Features:");
            Features.ForEach(f => Console.WriteLine(" - " + f));
            Console.WriteLine();
        }
    }

    class DomesticSubscription : Subscription
    {
        public override string Name => "Domestic";
        public override decimal MonthlyFee => 10;
        public override int MinPeriod => 6;
        public override List<string> Features => new List<string> { "Basic Channels", "HD Quality" };
    }

    class EducationalSubscription : Subscription
    {
        public override string Name => "Educational";
        public override decimal MonthlyFee => 8;
        public override int MinPeriod => 3;
        public override List<string> Features => new List<string> { "Educational Channels", "Documentaries", "Online Courses" };
    }

    class PremiumSubscription : Subscription
    {
        public override string Name => "Premium";
        public override decimal MonthlyFee => 20;
        public override int MinPeriod => 12;
        public override List<string> Features => new List<string> { "All Channels", "4K Quality", "No Ads", "Sports Package" };
    }
}

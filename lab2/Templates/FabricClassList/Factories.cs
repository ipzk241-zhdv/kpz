namespace FabricClassList
{
    public abstract class SubscriptionFactory
    {
        public abstract Subscription CreateSubscription();
    }

    public class DomesticSubscriptionFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new DomesticSubscription();
    }

    public class EducationalSubscriptionFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new EducationalSubscription();
    }

    public class PremiumSubscriptionFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new PremiumSubscription();
    }
}

namespace Templates.Decorator
{
    public abstract class HeroDecorator : IHero
    {
        protected IHero _hero;

        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string GetDescription() => _hero.GetDescription();
        public virtual int GetPower() => _hero.GetPower();
    }

    public class Weapon : HeroDecorator
    {
        public Weapon(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " + Sword";
        public override int GetPower() => _hero.GetPower() + 5;
    }

    public class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " + Armor";
        public override int GetPower() => _hero.GetPower() + 3;
    }

    public class Artifact : HeroDecorator
    {
        public Artifact(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " + Magic Artifact";
        public override int GetPower() => _hero.GetPower() + 7;
    }
}

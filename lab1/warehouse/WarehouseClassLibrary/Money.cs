namespace WarehouseClassLibrary
{
    public abstract class Money
    {
        public int WholePart { get; protected set; }
        public int Cents { get; protected set; }

        private static readonly Dictionary<string, decimal> ExchangeRates = new()
        {
            { "USD", 1.0m },
            { "EUR", 0.92m },
            { "UAH", 39.5m }
        };

        protected Money(int wholePart, int cents)
        {
            SetAmount(wholePart, cents);
        }

        public void SetAmount(int wholePart, int cents)
        {
            WholePart = wholePart + cents / 100;
            Cents = cents % 100;
        }

        protected abstract string GetCurrencyCode();

        /// <summary>
        /// Конвертує суму в цільову валюту.
        /// </summary>
        public Money ConvertTo(string targetCurrency)
        {
            decimal factor = ExchangeRates[targetCurrency] / ExchangeRates[this.GetCurrencyCode()];
            int totalCents = this.WholePart * 100 + this.Cents;
            int newTotalCents = (int)Math.Round(totalCents * factor, MidpointRounding.AwayFromZero);
            int newWhole = newTotalCents / 100;
            int newCents = newTotalCents % 100;
            return targetCurrency switch
            {
                "USD" => new Dollar(newWhole, newCents),
                "EUR" => new Euro(newWhole, newCents),
                _ => new Hryvnia(newWhole, newCents)
            };
        }

        protected abstract Money CreateInstance(int wholePart, int cents);

        public override string ToString()
        {
            return $"{WholePart}.{Cents:D2} {GetCurrencyCode()}";
        }

        public Money Add(Money other)
        {
            other = other.ConvertTo(this.GetCurrencyCode());
            int totalCents = (this.WholePart * 100 + this.Cents) + (other.WholePart * 100 + other.Cents);
            int newWhole = totalCents / 100;
            int newCents = totalCents % 100;
            return CreateInstance(newWhole, newCents);
        }

        public Money Subtract(Money other)
        {
            other = other.ConvertTo(this.GetCurrencyCode());
            int totalCents = (this.WholePart * 100 + this.Cents) - (other.WholePart * 100 + other.Cents);
            if (totalCents < 0)
                throw new InvalidOperationException("Результат віднімання не може бути від'ємним.");
            int newWhole = totalCents / 100;
            int newCents = totalCents % 100;
            return CreateInstance(newWhole, newCents);
        }

        public Money Multiply(decimal multiplier)
        {
            int totalCents = this.WholePart * 100 + this.Cents;
            int newTotalCents = (int)Math.Round(totalCents * multiplier, MidpointRounding.AwayFromZero);
            int newWhole = newTotalCents / 100;
            int newCents = newTotalCents % 100;
            return CreateInstance(newWhole, newCents);
        }

        public Money Divide(decimal divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Ділення на нуль.");
            int totalCents = this.WholePart * 100 + this.Cents;
            int newTotalCents = (int)Math.Round(totalCents / divisor, MidpointRounding.AwayFromZero);
            int newWhole = newTotalCents / 100;
            int newCents = newTotalCents % 100;
            return CreateInstance(newWhole, newCents);
        }
    }

    public class Dollar : Money
    {
        public Dollar(int wholePart, int cents) : base(wholePart, cents) { }
        protected override string GetCurrencyCode() => "USD";
        protected override Money CreateInstance(int wholePart, int cents) => new Dollar(wholePart, cents);
    }

    public class Euro : Money
    {
        public Euro(int wholePart, int cents) : base(wholePart, cents) { }
        protected override string GetCurrencyCode() => "EUR";
        protected override Money CreateInstance(int wholePart, int cents) => new Euro(wholePart, cents);
    }

    public class Hryvnia : Money
    {
        public Hryvnia(int wholePart, int cents) : base(wholePart, cents) { }
        protected override string GetCurrencyCode() => "UAH";
        protected override Money CreateInstance(int wholePart, int cents) => new Hryvnia(wholePart, cents);
    }
}

using System.Collections.Generic;

namespace SOLID_Fundamentals
{
    //  СТРАТЕГИИ ДЛЯ СКИДОК 
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal orderAmount);
        string StrategyName { get; }
    }

    public class RegularDiscount : IDiscountStrategy
    {
        public string StrategyName => "Regular";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.05m;
    }

    public class PremiumDiscount : IDiscountStrategy
    {
        public string StrategyName => "Premium";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.10m;
    }

    public class VIPDiscount : IDiscountStrategy
    {
        public string StrategyName => "VIP";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.15m;
    }

    public class StudentDiscount : IDiscountStrategy
    {
        public string StrategyName => "Student";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.08m;
    }

    public class SeniorDiscount : IDiscountStrategy
    {
        public string StrategyName => "Senior";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.07m;
    }

    //  СТРАТЕГИИ ДЛЯ ДОСТАВКИ 
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, string destination);
        string MethodName { get; }
    }

    public class StandardShipping : IShippingStrategy
    {
        public string MethodName => "Standard";
        public decimal CalculateShippingCost(decimal weight, string destination)
            => 5.00m + (weight * 0.5m);
    }

    public class ExpressShipping : IShippingStrategy
    {
        public string MethodName => "Express";
        public decimal CalculateShippingCost(decimal weight, string destination)
            => 15.00m + (weight * 1.0m);
    }

    public class OvernightShipping : IShippingStrategy
    {
        public string MethodName => "Overnight";
        public decimal CalculateShippingCost(decimal weight, string destination)
            => 25.00m + (weight * 2.0m);
    }

    public class InternationalShipping : IShippingStrategy
    {
        public string MethodName => "International";
        public decimal CalculateShippingCost(decimal weight, string destination)
        {
            return destination switch
            {
                "USA" => 30.00m,
                "Europe" => 35.00m,
                "Asia" => 40.00m,
                _ => 50.00m
            };
        }
    }

    public class DiscountCalculator
    {
        private readonly Dictionary<string, IDiscountStrategy> _discountStrategies
            = new Dictionary<string, IDiscountStrategy>();
        private readonly Dictionary<string, IShippingStrategy> _shippingStrategies
            = new Dictionary<string, IShippingStrategy>();

        public DiscountCalculator()
        {
            // Регистрация стратегий скидок
            RegisterDiscountStrategy(new RegularDiscount());
            RegisterDiscountStrategy(new PremiumDiscount());
            RegisterDiscountStrategy(new VIPDiscount());
            RegisterDiscountStrategy(new StudentDiscount());
            RegisterDiscountStrategy(new SeniorDiscount());

            // Регистрация стратегий доставки
            RegisterShippingStrategy(new StandardShipping());
            RegisterShippingStrategy(new ExpressShipping());
            RegisterShippingStrategy(new OvernightShipping());
            RegisterShippingStrategy(new InternationalShipping());
        }

        public void RegisterDiscountStrategy(IDiscountStrategy strategy)
        {
            _discountStrategies[strategy.StrategyName] = strategy;
        }

        public void RegisterShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategies[strategy.MethodName] = strategy;
        }

        public decimal CalculateDiscount(string customerType, decimal orderAmount)
        {
            if (_discountStrategies.TryGetValue(customerType, out var strategy))
            {
                return strategy.CalculateDiscount(orderAmount);
            }
            return 0;
        }

        public decimal CalculateShippingCost(string shippingMethod, decimal weight, string destination)
        {
            if (_shippingStrategies.TryGetValue(shippingMethod, out var strategy))
            {
                return strategy.CalculateShippingCost(weight, destination);
            }
            return 0;
        }
    }
}
using System;

namespace SOLID_Fundamentals
{
    // === ИНТЕРФЕЙСЫ ДЛЯ РАЗДЕЛЕНИЯ ОТВЕТСТВЕННОСТИ ===
    public interface IWithdrawable
    {
        bool CanWithdraw(decimal amount, out string reason);
        void Withdraw(decimal amount);
    }

    public interface IInterestBearing
    {
        decimal CalculateInterest();
    }

    // === БАЗОВЫЙ КЛАСС ===
    public abstract class Account
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            Balance += amount;
        }
    }

    // === SavingsAccount — реализует IWithdrawable ===
    public class SavingsAccount : Account, IWithdrawable, IInterestBearing
    {
        public decimal MinimumBalance { get; } = 100m;

        public bool CanWithdraw(decimal amount, out string reason)
        {
            if (Balance - amount < MinimumBalance)
            {
                reason = "Cannot go below minimum balance";
                return false;
            }
            reason = null;
            return true;
        }

        public void Withdraw(decimal amount)
        {
            if (!CanWithdraw(amount, out var reason))
                throw new InvalidOperationException(reason);
            Balance -= amount;
        }

        public decimal CalculateInterest() => Balance * 0.01m;
    }

    // === CheckingAccount — реализует IWithdrawable ===
    public class CheckingAccount : Account, IWithdrawable, IInterestBearing
    {
        public decimal OverdraftLimit { get; } = 500m;

        public bool CanWithdraw(decimal amount, out string reason)
        {
            if (Balance - amount < -OverdraftLimit)
            {
                reason = "Overdraft limit exceeded";
                return false;
            }
            reason = null;
            return true;
        }

        public void Withdraw(decimal amount)
        {
            if (!CanWithdraw(amount, out var reason))
                throw new InvalidOperationException(reason);
            Balance -= amount;
        }

        public decimal CalculateInterest() => Balance * 0.005m;
    }

    // === FixedDepositAccount — НЕ реализует IWithdrawable (нельзя снимать когда угодно) ===
    public class FixedDepositAccount : Account, IInterestBearing
    {
        public DateTime MaturityDate { get; }

        public FixedDepositAccount(DateTime maturityDate)
        {
            MaturityDate = maturityDate;
        }

        // Специальный метод — только после даты созревания
        public void WithdrawAfterMaturity(decimal amount)
        {
            if (DateTime.Now < MaturityDate)
                throw new InvalidOperationException("Cannot withdraw before maturity date");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");
            Balance -= amount;
        }

        public decimal CalculateInterest() => Balance * 0.05m;
    }

    // === Bank — работает только с теми, кто реализует IWithdrawable ===
    public class Bank
    {
        public bool ProcessWithdrawal(IWithdrawable account, decimal amount)
        {
            if (account.CanWithdraw(amount, out var reason))
            {
                account.Withdraw(amount);
                Console.WriteLine($"Successfully withdrew {amount}");
                return true;
            }
            Console.WriteLine($"Withdrawal failed: {reason}");
            return false;
        }

        public void Transfer(IWithdrawable from, Account to, decimal amount)
        {
            if (from.CanWithdraw(amount, out _))
            {
                from.Withdraw(amount);
                to.Deposit(amount);
                Console.WriteLine($"Transferred {amount}");
            }
            else
            {
                Console.WriteLine("Transfer failed: source account cannot withdraw");
            }
        }
    }
}
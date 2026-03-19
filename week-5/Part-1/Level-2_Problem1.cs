using System;

namespace BankAccount2
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
    class BankAccount2
    {
        private double balance;
        public BankAccount2(double balance)
        {
            this.balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }
            balance -= amount;
            Console.WriteLine("Withdrawal successful. Remaining Balance: " + balance);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Balance: ");
            double bal = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double amt = double.Parse(Console.ReadLine());

            BankAccount2 account = new BankAccount2(bal);

            try
            {
                account.Withdraw(amt);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed");
            }
        }
    }
}

namespace BankAccount
{
    class BankAccount
    {
        private int accountNumber;
        private double balance;
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
            }
            else
            {
                balance += amount;
                Console.WriteLine("Amount Deposited: " + amount);
                Console.WriteLine("Current Balance = " + balance);
            }
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Amount Withdrawn: " + amount);
                Console.WriteLine("Current Balance = " + balance);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            Console.Write("Enter Account Number: ");
            acc.AccountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            acc.Deposit(depositAmount);

            Console.Write("Enter Withdrawal Amount: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
            acc.Withdraw(withdrawAmount);
        }
    }
}

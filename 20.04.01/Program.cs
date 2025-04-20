using System;

class CreditCard
{
    public string CardNumber { get; set; }
    public string OwnerName { get; set; }
    public string ExpiryDate { get; set; }
    public string PIN { get; set; }
    public double CreditLimit { get; set; }
    public double Balance { get; set; }

    // Делегати для обробки подій
    public delegate void CardEvent(string message);

    // Події для різних ситуацій
    public event CardEvent OnDeposit;
    public event CardEvent OnWithdrawal;
    public event CardEvent OnCreditUsageStarted;
    public event CardEvent OnBalanceThresholdReached;
    public event CardEvent OnPinChanged;


    public CreditCard(string cardNumber, string ownerName, string expiryDate, string pin, double creditLimit, double initialBalance)
    {
        CardNumber = cardNumber;
        OwnerName = ownerName;
        ExpiryDate = expiryDate;
        PIN = pin;
        CreditLimit = creditLimit;
        Balance = initialBalance;
    }

    
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount to deposit must be positive.");
            return;
        }

        Balance += amount;
        OnDeposit?.Invoke($"Deposited {amount}. New balance: {Balance}");
    }

    
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount to withdraw must be positive.");
            return;
        }

        if (Balance + CreditLimit < amount)
        {
            OnWithdrawal?.Invoke($"Insufficient funds to withdraw {amount}. Balance: {Balance}, Credit Limit: {CreditLimit}");
        }
        else
        {
            Balance -= amount;
            if (Balance < 0)
            {
                OnCreditUsageStarted?.Invoke($"Credit usage started. Balance: {Balance}");
            }
            OnWithdrawal?.Invoke($"Withdrew {amount}. New balance: {Balance}");
        }
    }

    public void ChangePin(string newPin)
    {
        PIN = newPin;
        OnPinChanged?.Invoke($"PIN changed successfully. New PIN: {newPin}");
    }

    
    public void CheckBalanceThreshold(double threshold)
    {
        if (Balance <= threshold)
        {
            OnBalanceThresholdReached?.Invoke($"Balance threshold reached. Current balance: {Balance}");
        }
    }
}

class Program
{
    static void Main()
    {
        CreditCard myCard = new CreditCard("1234 5678 9101 1121", "John Doe", "12/25", "1234", 5000, 1000);

       
        myCard.OnDeposit += message => Console.WriteLine(message);
        myCard.OnWithdrawal += message => Console.WriteLine(message);
        myCard.OnCreditUsageStarted += message => Console.WriteLine(message);
        myCard.OnBalanceThresholdReached += message => Console.WriteLine(message);
        myCard.OnPinChanged += message => Console.WriteLine(message);

       
        myCard.Deposit(500);
        myCard.Withdraw(1500);
        myCard.Withdraw(3500); 
        myCard.CheckBalanceThreshold(500);
        myCard.ChangePin("5678");
    }
}

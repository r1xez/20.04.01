using System;

class CreditCard
{
    public string CardNumber { get; set; }
    public string OwnerName { get; set; }
    public string ExpiryDate { get; set; }
    public string PIN { get; set; }
    public double CreditLimit { get; set; }
    public double Balance { get; set; }

    
    public delegate void CardOperation(string message);

   
    public void CheckBalance()
    {
        Console.WriteLine($"Balance: {Balance}");
    }

  
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} to the account. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Amount to deposit must be positive.");
        }
    }

    
    public void Withdraw(double amount, CardOperation operation)
    {
        if (amount <= 0)
        {
            operation("Amount to withdraw must be positive.");
            return;
        }

        if (amount > Balance)
        {
            operation("Insufficient funds.");
        }
        else
        {
            Balance -= amount;
            operation($"Withdrew {amount} from the account. New balance: {Balance}");
        }
    }

    
    public CreditCard(string cardNumber, string ownerName, string expiryDate, string pin, double creditLimit, double initialBalance)
    {
        CardNumber = cardNumber;
        OwnerName = ownerName;
        ExpiryDate = expiryDate;
        PIN = pin;
        CreditLimit = creditLimit;
        Balance = initialBalance;
    }
}

class Program
{
    static void Main()
    {
        
        CreditCard myCard = new CreditCard("1234 5678 9101 1121", "John Doe", "12/25", "1234", 5000, 1000);

        
        CreditCard.CardOperation operation = message => Console.WriteLine(message);

        myCard.CheckBalance();

     
        myCard.Deposit(500);

        myCard.Withdraw(200, operation);

       
        myCard.Withdraw(1500, operation);
    }
}

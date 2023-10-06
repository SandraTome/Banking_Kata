using System.Text;
using System.Transactions;

namespace Banking_Kata;

public class Account
{
    public int Balance { get; private set; }
    public List<Transaction> Transactions { get; } = new List<Transaction>();

    public Account(int initialBalance)
    {
        Balance = initialBalance;
    }
    
    public void Deposit(int amount)
    {   if (amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
        Balance += amount;
        Transactions.Add(new Transaction(amount, Balance, DateTime.Now));
    }
    
    public void Withdraw(int amount)
    {
        if (Balance < amount)
        {
            throw new Exception("Insufficient funds");
        }
        Balance -= amount;
        Transactions.Add(new Transaction(-amount, Balance, DateTime.Now));
    }
    
    public string PrintStatement()
    {
        var statement = new StringBuilder();
        statement.AppendLine("Date || Amount || Balance");
        foreach (var transaction in Transactions)
        {
            statement.AppendLine($"{transaction.Date.ToShortDateString()} || {transaction.Amount} || {transaction.Balance}");
        }
        return statement.ToString();
        
    }
    
}
namespace Banking_Kata;

public class Transaction: ITransaction  
{
    public int Amount { get; }
    public int Balance { get; }
    public DateTime Date { get; }

    public Transaction(int amount, int balance, DateTime date)
    {
        Amount = amount;
        Balance = balance;
        Date = date;
    }
}
namespace Banking_Kata;

public interface ITransaction
{
    int Amount { get; }
    int Balance { get; }
    DateTime Date { get; }
    
}
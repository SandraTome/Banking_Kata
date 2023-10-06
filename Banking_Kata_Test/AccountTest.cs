using Banking_Kata;

namespace Banking_Kata_Test;

public class AccountTest
{
    [Theory]
    [InlineData(0, 100, 100)]
    [InlineData(100, 100, 200)]
    [InlineData(200, 100, 300)]
    public void Deposit_BalanceIncreasesWhenMakingADeposit(int balance, int amountToDeposit, int expectedBalance)
    {
        // Arrange
        var account = new Account(balance);
        
        // Act
        account.Deposit(amountToDeposit);
        
        // Assert
        Assert.Equal(expectedBalance, account.Balance);
    }
    
    [Fact]
    public void Deposit_ThrowsExceptionWhenAmountIsLessThanOrEqualToZero()
    {
        // Arrange
        var account = new Account(0);
        
        // Act
        var exception = Assert.Throws<Exception>(() => account.Deposit(-100));
        
        // Assert
        Assert.Equal("Amount must be greater than 0", exception.Message);
    }
    
    
    [Theory]
    [InlineData(100, 50, 50)]
    [InlineData(200, 50, 150)]
    [InlineData(300, 50, 250)]
    public void Withdraw_BalanceDecreasesWhenMakingAWithdrawal(int balance, int amountToWithdraw, int expectedBalance)
    {
        // Arrange
        var account = new Account(balance);
        
        // Act
        account.Withdraw(amountToWithdraw);
        
        // Assert
        Assert.Equal(expectedBalance, account.Balance);
    }
    
    [Fact]
    public void Withdraw_ThrowsExceptionWhenBalanceIsLessThanAmountToWithdraw()
    {
        // Arrange
        var account = new Account(0);
        
        // Act
        var exception = Assert.Throws<Exception>(() => account.Withdraw(100));
        
        // Assert
        Assert.Equal("Insufficient funds", exception.Message);
    }

    [Fact]
    public void PrintStatement_PrintsStatement()
    {
        // Arrange
        var account = new Account(0);
        account.Deposit(1000);
        account.Withdraw(100);
        account.Deposit(500);
        var printStatement = "Date || Amount || Balance\n" +
                             $"{DateTime.Now.ToShortDateString()} || 1000 || 1000\n" +
                             $"{DateTime.Now.ToShortDateString()} || -100 || 900\n" +
                             $"{DateTime.Now.ToShortDateString()} || 500 || 1400\n";

        // Act
        var statement = account.PrintStatement();
        
        // Assert
        Assert.Equal(printStatement, statement);
    }
    
    
}
using OOProgramming;

IntroToClasses();

// <FirstTests>
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());
// </FirstTests>

// <TestLineOfCredit>
var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());
// </TestLineOfCredit>
static void IntroToClasses()
{
    var account = new BankAccount("<name>", 1000);
    Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} balance.");

    account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
    Console.WriteLine(account.Balance);
    account.MakeDeposit(100, DateTime.Now, "friend paid me back");
    Console.WriteLine(account.Balance);

    Console.WriteLine(account.GetAccountHistory());

    // Test that the initial balances must be positive:
    try
    {
        var invalidAccount = new BankAccount("invalid", -55);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine("Exception caught creating account with negative balance");
        Console.WriteLine(e.ToString());
    }

    // Test for a negative balance
    try
    {
        account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine("Exception caught trying to overdraw");
        Console.WriteLine(e.ToString());
    }
}
//THIS IS THE MIDTERM THAT WAS ADDED
// Create a new CD account with a 6-month term and 5% interest rate
var myCD = new CD("John Doe", 1000m, 0.05m, 6);

// Try to perform month-end transactions (interest should not be applied yet)
Console.WriteLine("Before maturity:");
myCD.PerformMonthEndTransactions();
Console.WriteLine($"Balance after first month-end: {myCD.Balance}");

// Simulate waiting until maturity
System.Threading.Thread.Sleep(2000); // Wait for 2 seconds to simulate passage of time

// Now try again after maturity
Console.WriteLine("\nAfter maturity:");
myCD.PerformMonthEndTransactions();
Console.WriteLine($"Balance after maturity: {myCD.Balance}");

// Test withdrawal after maturity
try
{
    myCD.MakeWithdrawal(500m, DateTime.Now, "Withdrawal after maturity");
    Console.WriteLine($"Balance after withdrawal: {myCD.Balance}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Test withdrawal before maturity (this should throw an exception)
try
{
    var earlyWithdrawal = new CD("John Doe", 1000m, 0.05m, 6);
    earlyWithdrawal.MakeWithdrawal(500m, DateTime.Now, "Early Withdrawal");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

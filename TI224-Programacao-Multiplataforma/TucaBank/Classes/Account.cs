namespace Classes;

public class Account
{
    private static int accountNumberSeed = 1234567890;
    protected string number;
    protected string owner;
    protected double balance;
    protected List<Transaction> transactions;

    public Account(string owner, double initialBalance)
    {
        this.number = accountNumberSeed.ToString();
        this.owner = owner;
        this.transactions = new List<Transaction>();
        this.MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        accountNumberSeed++;
    }

    public Account(string owner) : this(owner, 0)
    {
        this.number = accountNumberSeed.ToString();
        this.owner = owner;
        this.transactions = new List<Transaction>();
    }

    public string GetNumber() => this.number;
    public string GetOwner() => this.owner;
    public double GetBalance() => this.balance;

    public void MakeDeposit(double amount, DateTime date, string notes)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

        this.balance += amount;
        this.transactions.Add(new Transaction(amount, date, notes));
    }

    public virtual void MakeWithdrawal(double amount, DateTime date, string notes)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

        if (balance - amount < 0)
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");

        this.balance -= amount;
        this.transactions.Add(new Transaction(-amount, date, notes));
    }

    public virtual void PerformMonthEndTransactions()
    {

    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        var balance = 0.0;

        foreach (var transaction in this.transactions)
        {
            balance += transaction.GetAmount();
            report.AppendLine($"{transaction.GetDate().ToShortDateString()}\t{transaction.GetAmount()}\t{balance}\t{transaction.GetNotes()}");
        }

        return report.ToString();
    }

    public override string ToString() => "${this.owner}, balance = R${this.balance()}";
}
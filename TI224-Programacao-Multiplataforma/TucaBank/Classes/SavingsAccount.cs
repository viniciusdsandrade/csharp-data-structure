namespace Classes;

public class SavingsAccount : Account
{
    private double annualRate = 0.001;

    public SavingsAccount(string owner, double interest) : this(owner, 0, interest)
    {
        this.owner = owner;
        this.transactions = new List<Transaction>();
    }

    public SavingsAccount(string owner, double balance, double interest) : base(owner, balance)
    {
        if (interest > 0)
            annualRate = interest;
    }

    public override void PerformMonthEndTransactions()
    {
        double interestEarned = balance * (annualRate / 12);
        base.MakeDeposit(interestEarned, DateTime.Now, "Apply monthly interest");
    }
}
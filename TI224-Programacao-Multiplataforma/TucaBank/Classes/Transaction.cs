namespace Classes;

public class Transaction
{
    private double amount;
    private DateTime date;
    private string notes;

    public Transaction(double amount, DateTime date, string notes)
    {
        this.amount = amount;
        this.date = date;
        this.notes = notes;
    }

    public double GetAmount() => this.amount;
    public DateTime GetDate() => this.date;
    public string GetNotes() => this.notes;
}
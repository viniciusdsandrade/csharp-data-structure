using System;

namespace Transaction
{
    public class Transaction
    {
        private double Amount;
        private DateTime Date;
        private string Notes;

        public Transaction()
        {
        }

        public Transaction(double amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }

        public Transaction(double amount, DateTime date, string notes) : this(amount, date)
        {
            this.Notes = notes;
        }

        public double GetAmount() => Amount;
        public DateTime GetDate() => Date;
        public string GetNotes() => Notes;
    }
}
using System.Text;

namespace BankAccount
{
    public class BankAccount : ICloneable
    {
        public string Number;
        public string Owner;
        public double Balance = 0;
        private List<Transaction.Transaction> Transaction = [];

        public BankAccount()
        {
        }

        public BankAccount(string number, string owner)
        {
            this.Number = number;
            this.Owner = owner;
        }

        // Reutilização do construtor
        public BankAccount(string number, string owner, double initialBalance) : this(number, owner)
        {
            this.Balance = initialBalance;
        }

        public string GetNumber() => Number;
        public string GetOwner() => Owner;
        public double GetBalance() => Balance;

        public void SetNumber(string number) => Number = number;
        public void SetOwner(string owner) => Owner = owner;

        public void MakeDeposit(double amount, DateTime date, string notes)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

            var deposit = new Transaction.Transaction(amount, date, notes);
            Transaction.Add(deposit);
            Balance += amount;
        }

        public void MakeWithdraw(double amount, DateTime date, string notes)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdraw must be positive");

            if (Balance - amount < 0)
                throw new InvalidOperationException("Not sufficient funds for this withdraw");

            var draw = new Transaction.Transaction(-amount, date, notes);
            Transaction.Add(draw);
            Balance -= amount;
        }
        
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            double balance = 0;

            report.AppendLine("Date\t\tAmount\tBalance\tNotes");
            foreach (var item in Transaction)
            {
                balance += item.GetAmount();
                report.AppendLine($"{item.GetDate().ToShortDateString()}\t{item.GetAmount()}\t{balance}\t{item.GetNotes()}");
            }

            return report.ToString();

        }

        public object Clone()
        {
            var account = new BankAccount(Number, Owner, Balance)
            {
                Transaction = [.. Transaction]
            };
            return account;
        }

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            var account = (BankAccount)obj;

            return account.Number == Number && 
                   account.Owner == Owner && 
                   account.Balance == Balance;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            var hash = 1;

            hash *= prime + Number.GetHashCode();
            hash *= prime + Owner.GetHashCode();
            hash *= prime + Balance.GetHashCode();

            foreach (var t in Transaction)
            {
                hash *= prime + t.GetAmount().GetHashCode();
                hash *= prime + t.GetDate().GetHashCode();
                hash *= prime + t.GetNotes().GetHashCode();
            }


            if (hash < 0) hash = -hash;


            return hash;
        }

        public override string ToString() => $"Number: {Number}, Owner: {Owner}, Balance: {Balance}";
    }
}
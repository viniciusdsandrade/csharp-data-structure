namespace revisao_prova_um
{
    public class Account
    {
        //atributes
        private string owner;
        private double balance;

        // properties não estao no construtor (NUNCA!)
        public string Number { get; set; }

        public Account()
        {
        }

        public Account(string owner, string number)
        {
            this.owner = owner;
            //this.number = number;
        }

        public Account(string owner, string number, double balance)
        {
            this.owner = owner;
            //this.number = number;
            this.balance = balance;
        }

        // Properties
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        // Properties
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string GetOwner()
        {
            return owner;
        }

        public string GetNumber()
        {
            return GetNumber();
        }

        public double GetBalance()
        {
            return balance;
        }


        public void MakeDeposit(double value)
        {
            if (value <= 0) throw new ArgumentException("The value must be greater than zero.");

            balance += value;
        }

        public void MakeWithdraw(double value)
        {
            if (value <= 0) throw new ArgumentException("The value must be greater than zero.");
            if (value > balance) throw new ArgumentException("Insufficient balance.");

            balance -= value;
        }

        public override string ToString()
        {
            return "Owner: " + owner +
                   "\nNumber: " + GetNumber() +
                   "\nBalance: " + balance;
        }
    }
}
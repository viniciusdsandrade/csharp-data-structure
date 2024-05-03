using Classes;

var account = new Account("Guilherme Macedo", 13000.00);
account.MakeDeposit(975, DateTime.Now, "Rent payment");
account.MakeWithdrawal(3000, DateTime.Now, "Emergency funds for repairs");
account.MakeDeposit(300, DateTime.Now, "Friend paid me back");
account.MakeWithdrawal(1500, DateTime.Now, "Take out monthly advance");

Console.WriteLine(account.GetAccountHistory());
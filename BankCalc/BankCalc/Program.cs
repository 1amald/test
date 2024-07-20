using BankCalc;

//JsonProvider.FillBanknotes()
var banknotes = JsonProvider.GetBanknotes();

Console.WriteLine("Enter sum");
var sum = Convert.ToInt32(Console.ReadLine());

var bankTerminal = new BankTerminal(banknotes);
Console.WriteLine(bankTerminal.SumCanBeGiven(sum));



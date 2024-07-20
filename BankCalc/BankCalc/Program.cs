using BankCalc;

//JsonProvider.FillBanknotes()
var banknotes = JsonProvider.GetBanknotes();
var bankTerminal = new BankTerminal(banknotes);

while (true)
{
    Console.WriteLine("Enter sum");
    var sum = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(bankTerminal.SumCanBeGiven(sum));
}



using BankCalc;

//await JsonProvider.FillBanknotes();
var banknotes = await JsonProvider.GetBanknotes();
var bankTerminal = new BankTerminal(banknotes);

while (true)
{
    Console.WriteLine("Введите сумму");

    if (InputValidator.AmountIsValid(Console.ReadLine()!, out var targetSum))
    {
        Console.WriteLine(bankTerminal.SumCanBeGiven(targetSum));
    }
}



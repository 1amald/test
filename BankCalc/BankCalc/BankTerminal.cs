namespace BankCalc;

internal sealed class BankTerminal
{
    private readonly int[] _banknotes;

    public BankTerminal(BanknoteQuantity[] banknoteQuantities)
    {
        _banknotes = banknoteQuantities
            .OrderByDescending(x => x.Nominal)
            .SelectMany(x => Enumerable.Range(1, x.Quantity).Select(_ => x.Nominal))
            .ToArray();
    }

    public bool SumCanBeGiven(int amount)
    {
        var sums = new HashSet<int>();
        sums.Add(0);

        for (var i = 0; i < _banknotes.Length; i++)
        {
            foreach (var sum in sums)
            {
                var newSum = sum + _banknotes[i];

                if (newSum == amount)
                {
                    return true;
                }

                if (newSum < amount && !sums.Contains(newSum))
                {
                    sums.Add(newSum);
                }
            }
        }

        return false;
    }
}
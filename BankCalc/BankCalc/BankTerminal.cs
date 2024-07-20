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

    public bool SumCanBeGiven(int targetSum)
    {
        var sums = new HashSet<int>
        {
            0
        };

        for (var i = 0; i < _banknotes.Length; i++)
        {
            if (_banknotes[i] > targetSum)
            {
                continue;
            }

            var newSums = new List<int>();

            foreach (var sum in sums)
            {
                var newSum = sum + _banknotes[i];

                if (newSum == targetSum)
                {
                    return true;
                }

                if (newSum < targetSum)
                {
                    newSums.Add(newSum);
                }
            }

            sums.UnionWith(newSums);
        }

        return false;
    }
}
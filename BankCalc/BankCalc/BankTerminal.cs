namespace BankCalc;

internal sealed class BankTerminal
{
    private Dictionary<int, int> BanknoteQuantities { get; }

    public BankTerminal(BanknoteQuantity[] banknoteQuantities)
    {
        BanknoteQuantities = banknoteQuantities
            .GroupBy(x => x.Nominal, x => x)
            .ToDictionary(x => x.Key, x => x.Sum(x => x.Quantity));
    }

    public bool SumCanBeGiven(int sum)
    {
        if (BanknoteQuantities.ContainsKey(sum))
        {
            return true;
        }

        var banknotesLst = new List<int>();

        foreach (var banknoteQuantity in BanknoteQuantities)
        {
            banknotesLst.AddRange(Enumerable.Range(1, banknoteQuantity.Value).Select(_ => banknoteQuantity.Key));
        }

        var banknotes = banknotesLst.ToArray();

        var result = Sums(banknotes, sum);

        return result;
    }

    private bool Sums(int[] arr, int target)
    {
        var stack = new int[arr.Length];
        var top = 0;

        var success = false;

        void Iteration(int i, int target)
        {
            if (target < 0)
            {
                return;
            }

            if (target == 0)
            {
                success = true;
                return;
            }

            if (i < arr.Length)
            {
                stack[top++] = arr[i];
                Iteration(i + 1, target - arr[i]);
                --top;
                Iteration(i + 1, target);
            }
        }

        Iteration(0, target);

        return success;
    }
}
using System.Text.Json;

namespace BankCalc;

internal static class JsonProvider
{
    private static string FilePath => "C:/repos/test/banknotesQuantities.json";

    public static BanknoteQuantity[] GetBanknotes()
    {
        var banknotesQuantitiesJson = File.ReadAllText(FilePath);
        var banknotesQuantities = JsonSerializer.Deserialize<BanknoteQuantity[]>(banknotesQuantitiesJson)!;

        return banknotesQuantities;
    }

    public static void FillBanknotes()
    {
        var banknotesQuantities = new[]
        {
            new BanknoteQuantity(5000, 10),
            new BanknoteQuantity(1000, 10),
            new BanknoteQuantity(500, 10),
            new BanknoteQuantity(100, 10)
        };
        File.WriteAllText(FilePath, JsonSerializer.Serialize(banknotesQuantities));
    }
}
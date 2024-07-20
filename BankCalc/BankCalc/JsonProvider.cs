using System.Text.Json;

namespace BankCalc;

internal static class JsonProvider
{
    private static string FilePath => "../banknotesQuantities.json";

    public static async Task<BanknoteQuantity[]> GetBanknotes()
    {
        var banknotesQuantitiesJson = await File.ReadAllTextAsync(FilePath);
        var banknotesQuantities = JsonSerializer.Deserialize<BanknoteQuantity[]>(banknotesQuantitiesJson)!;

        return banknotesQuantities;
    }

    public static async Task FillBanknotes()
    {
        var banknotesQuantities = new[]
        {
            new BanknoteQuantity(5000, 10),
            new BanknoteQuantity(1000, 10),
            new BanknoteQuantity(500, 10),
            new BanknoteQuantity(100, 10)
        };

        await File.WriteAllTextAsync(FilePath, JsonSerializer.Serialize(banknotesQuantities));
    }
}
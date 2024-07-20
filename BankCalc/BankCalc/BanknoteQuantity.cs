namespace BankCalc;

public sealed class BanknoteQuantity
{
    public int Nominal { get; set; }
    public int Quantity { get; set; }

    public BanknoteQuantity(int nominal, int quantity)
    {
        Nominal = nominal;
        Quantity = quantity;
    }
}
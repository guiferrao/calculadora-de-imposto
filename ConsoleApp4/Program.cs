using System.Formats.Tar;

public interface ITaxService
{
    double CalculateTax(double value);
}

public class BrazilTaxService : ITaxService
{
    public double CalculateTax(double value)
    {
        var BrazilTax = value * 0.10;
        Console.WriteLine($"O valor do imposto brasileiro é {BrazilTax}");
        return BrazilTax;
    }
}

public class USTaxService : ITaxService
{
    public double CalculateTax(double value)
    {
        var USTax = value * 0.05;
        Console.WriteLine($"O valor do imposto americano é {USTax}");
        return USTax;
    }
}

public class EuropeTaxService : ITaxService
{
    public double CalculateTax(double value)
    {
        var EuropeTax = value * 0.20;
        Console.WriteLine($"O valor do imposto europeu é {EuropeTax}");
        return EuropeTax;
    }
}

public class PriceCalculator
{
    private readonly ITaxService _taxService;

    public PriceCalculator(ITaxService taxService)
    {
        _taxService = taxService;
    }

    public double FinalPrice(double baseValue)
    {
        double calculatedTax = _taxService.CalculateTax(baseValue);
        return baseValue + calculatedTax;
    }
}

class Program
{
    static void Main()
    {
        ITaxService brasilTax = new BrazilTaxService();
        var calculatorBrazil = new PriceCalculator(brasilTax);
        Console.WriteLine($"Preço final no Brasil: {calculatorBrazil.FinalPrice(100.00):C}");

        ITaxService USTax = new USTaxService();
        var calculatorUS = new PriceCalculator(USTax);
        Console.WriteLine($"preço final no US: {calculatorUS.FinalPrice(50.00):C}");

        ITaxService EuropeTax = new EuropeTaxService();
        var calculatorEurope = new PriceCalculator(EuropeTax);
        Console.WriteLine($"preço final na europa: {calculatorUS.FinalPrice(75.00):C}");
    }
}

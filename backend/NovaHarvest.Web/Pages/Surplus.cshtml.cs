using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;

namespace NovaHarvest.Web.Pages;

public class SurplusModel : PageModel
{
    private const decimal SurplusDiscount = 0.30m;
    private const int BoxKg = 5;
    private const int ShelfLifeDays = 7;
    private const int LowStockKg = 50;

    public Surplus Surplus { get; } = new()
    {
        Product = "Cereza Picota",
        Producer = "Huerta Los Castaños",
        Village = "Cabezuela del Valle",
        HarvestDate = DateTime.Today.AddDays(-2),
        AvailableKg = 343,
        ReservedKg = 120,
        PricePerKg = 3.20m,
        Note = "<b>Recoger antes de las 14:00</b>"
    };

    public DateTime ExpiryDate { get; private set; }
    public int DaysLeft { get; private set; }
    public decimal SurplusPrice { get; private set; }
    public int RemainingKg { get; private set; }
    public int FullBoxes { get; private set; }
    public int LooseKg { get; private set; }
    public decimal TotalValue { get; private set; }
    public string Status { get; private set; } = "";
    public bool IsSoldOut { get; private set; }
    public bool IsUrgent { get; private set; }

    public void OnGet()
    {
        ExpiryDate = Surplus.HarvestDate.AddDays(ShelfLifeDays);
        DaysLeft = (ExpiryDate - DateTime.Today).Days;
        SurplusPrice = Surplus.PricePerKg * (1 - SurplusDiscount);
        RemainingKg = Surplus.AvailableKg - Surplus.ReservedKg;
        FullBoxes = RemainingKg / BoxKg;
        LooseKg = RemainingKg % BoxKg;
        TotalValue = RemainingKg * SurplusPrice;
        IsSoldOut = RemainingKg == 0;
        IsUrgent = DaysLeft <= 2 && RemainingKg > 0;

        if (IsSoldOut)
        {
            Status = "Agotado";
        }
        else if (RemainingKg < LowStockKg)
        {
            Status = "Ultimos kilos";
        }
        else
        {
            Status = "Disponible";
        }
    }
}
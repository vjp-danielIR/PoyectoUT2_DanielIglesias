using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NovaHarvest.Web.Pages.Reservations;

public class TicketModel : PageModel
{
    public string ReservationCode { get; } = "RES-0001";
    public string Product { get; } = "Cereza Picota";
    public int Kilos { get; } = 20;
    public string PickupPlace { get; } = "Cooperativa del Valle del Jerte";
    public DateTime GeneratedAt { get; private set; }

    public void OnGet()
    {
        GeneratedAt = DateTime.Now;
    }
}
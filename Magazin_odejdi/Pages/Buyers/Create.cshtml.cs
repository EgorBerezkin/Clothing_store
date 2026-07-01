using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Magazin_odejdi.Hubs;


namespace Magazin_odejdi.Pages.Buyers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<BuyersHub> _hubContext;
        public CreateModel(ApplicationDbContext context, IHubContext<BuyersHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Buyer Buyer { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Buyers.Add(Buyer);
            _context.SaveChanges();
            _hubContext.Clients.All.SendAsync("BuyersUpdated");

            return RedirectToPage("Index");
        }

    }
}

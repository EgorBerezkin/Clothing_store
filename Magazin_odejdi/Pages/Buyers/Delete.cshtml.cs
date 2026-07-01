using Magazin_odejdi.Data;
using Magazin_odejdi.Hubs;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Magazin_odejdi.Pages.Buyers
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<BuyersHub> _hubContext;

        public DeleteModel(ApplicationDbContext context, IHubContext<BuyersHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Buyer Buyer { get; set; }

        public IActionResult OnGet(int id)
        {
            Buyer = _context.Buyers.Find(id);

            if (Buyer == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var buyer = _context.Buyers.Find(Buyer.Id);

            if (buyer != null)
            {
                _context.Buyers.Remove(buyer);
                _context.SaveChanges();
                _hubContext.Clients.All.SendAsync("BuyersUpdated");
            }

            return RedirectToPage("Index");
        }
    }
}

using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magazin_odejdi.Pages.Buyers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Buyer Buyer { get; set; }

        public IActionResult OnGet(int id)
        {
            Buyer = _context.Buyers.FirstOrDefault(s => s.Id == id);

            if (Buyer == null)
                return NotFound();

            return Page();
        }
    }
}

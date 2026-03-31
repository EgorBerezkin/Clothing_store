using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;

namespace Magazin_odejdi.Pages.Buyers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buyer Buyer { get; set; }

        public IActionResult OnGet(string FIO)
        {
            Buyer = _context.Buyers.Find(FIO);

            if (Buyer == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var participant = _context.Buyers.Find(Buyer.FIO);

            if (participant != null)
            {
                _context.Buyers.Remove(participant);
                //_context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}

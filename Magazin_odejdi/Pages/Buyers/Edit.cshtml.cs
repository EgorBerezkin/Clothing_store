using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magazin_odejdi.Pages.Buyers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
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
            if (!ModelState.IsValid)
                return Page();

            _context.Buyers.Update(Buyer);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

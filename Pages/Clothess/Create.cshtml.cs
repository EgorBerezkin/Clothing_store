using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;

namespace Magazin_odejdi.Pages.Clothess
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothes Clothes { get; set; } = new Clothes();
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Clothess.Add(Clothes);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

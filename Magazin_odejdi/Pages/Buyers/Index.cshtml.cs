using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;

namespace Magazin_odejdi.Pages.Buyers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Buyer> Buyers { get; set; }

        public void OnGet()
        {
            Buyers = _context.Buyers.ToList();
        }
    }
}

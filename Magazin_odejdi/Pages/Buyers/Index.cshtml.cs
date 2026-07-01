using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magazin_odejdi.Pages.Buyers
{
    [Authorize]
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

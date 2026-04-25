using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;

namespace Magazin_odejdi.Pages.Clothess
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Clothes? Clothes { get; set; }

        public IActionResult OnGet(int id)
        {
            Clothes = _context.Clothess.FirstOrDefault(s => s.Id == id);

            if (Clothes == null)
                return NotFound();

            return Page();
        }
    }
}

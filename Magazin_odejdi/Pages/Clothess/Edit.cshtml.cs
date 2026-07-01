using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin_odejdi.Pages.Clothess
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothes? Clothes { get; set; }

        public IActionResult OnGet(int id)
        {
            Clothes = _context.Clothess
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

            if (Clothes == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Clothess.Update(Clothes);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

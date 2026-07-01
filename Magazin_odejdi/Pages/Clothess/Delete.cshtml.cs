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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothes? Clothes { get; set; }

        public IActionResult OnGet(int id)
        {
            Clothes = _context.Clothess.FirstOrDefault(c => c.Id == id);
            

            if (Clothes == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var book = _context.Clothess.Find(Clothes.Id);

            if (book != null)
            {
                _context.Clothess.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}

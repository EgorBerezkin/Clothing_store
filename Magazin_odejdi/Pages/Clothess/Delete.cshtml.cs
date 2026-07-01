using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.SignalR;
using Magazin_odejdi.Hubs;

namespace Magazin_odejdi.Pages.Clothess
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ClothesHub> _hubContext;

        public DeleteModel(ApplicationDbContext context, IHubContext<ClothesHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
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

                _hubContext.Clients.All.SendAsync("ClothesUpdated", Clothes.Id);
            }

            return RedirectToPage("Index");
        }
    }
}

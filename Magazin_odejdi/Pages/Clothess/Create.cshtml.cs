using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazin_odejdi.Data;
using Magazin_odejdi.Model;
using Microsoft.AspNetCore.SignalR;
using Magazin_odejdi.Hubs;

namespace Magazin_odejdi.Pages.Clothess
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ClothesHub> _hubContext;

        public CreateModel(ApplicationDbContext context, IHubContext<ClothesHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Clothes Clothes { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Clothess.Add(Clothes);
            _context.SaveChanges();
            _hubContext.Clients.All.SendAsync("ClothesUpdated", Clothes);
            return RedirectToPage("Index");
        }
    }
}

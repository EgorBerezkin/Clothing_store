using Magazin_odejdi.Data;
using Magazin_odejdi.Hubs;
using Magazin_odejdi.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Magazin_odejdi.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<UsersHub> _hubContext;

        public CreateModel(ApplicationDbContext context, IHubContext<UsersHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        [BindProperty]
        public IFormFile? AvatarFile { get; set; }

        public void OnGet()
        {
            User = new AuthUser();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (AvatarFile != null)
            {
                if (AvatarFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "File too large");
                    return Page();
                }

                using (var ms = new MemoryStream())
                {
                    await AvatarFile.CopyToAsync(ms);
                    User.Avatar = ms.ToArray();
                }
            }
            if (User.Id > 0) 
            {
                _context.Attach(User).State = EntityState.Modified;
            }
            else
            {
                

                await _context.AuthUsers.AddAsync(User);
            }

            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("UsersUpdated");

            return RedirectToPage("Index");
        }
    }
}

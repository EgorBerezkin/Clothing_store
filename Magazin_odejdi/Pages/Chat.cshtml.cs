using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magazin_odejdi.Pages
{
    [Authorize]
    public class ChatModel : PageModel
    {
        public string Users { get; set; } = "Гость";
        public void OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                Users = User.Identity.Name!;
            }
        }
    }
}

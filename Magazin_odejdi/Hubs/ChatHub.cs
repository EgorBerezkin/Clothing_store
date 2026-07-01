using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Magazin_odejdi.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            string role = Context.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "User";
            string time = DateTime.Now.ToString("HH:mm");

            await Clients.All.SendAsync("Receive", user, message);
        }
    }
}

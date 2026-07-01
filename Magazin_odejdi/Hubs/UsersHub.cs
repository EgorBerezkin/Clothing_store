using Magazin_odejdi.Model;
using Magazin_odejdi.Model.AuthApp;
using Microsoft.AspNetCore.SignalR;

namespace Magazin_odejdi.Hubs
{
    public class UsersHub : Hub
    {
        public async Task SendClothesUpdate(AuthUser authuser)
        {
            await Clients.All.SendAsync("AuthUserUpdated", authuser);
        }
    }
}

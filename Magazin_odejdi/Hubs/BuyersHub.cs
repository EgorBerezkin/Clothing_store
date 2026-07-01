using Magazin_odejdi.Model;
using Microsoft.AspNetCore.SignalR;

namespace Magazin_odejdi.Hubs
{
    public class BuyersHub : Hub
    {
        // Отправка обновления одежда всем клиентам
        public async Task SendClothesUpdate(Buyer buyers)
        {
            await Clients.All.SendAsync("BuyersUpdated", buyers);
        }
    }
}

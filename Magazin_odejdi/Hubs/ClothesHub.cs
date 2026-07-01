using Magazin_odejdi.Model;
using Microsoft.AspNetCore.SignalR;

namespace Magazin_odejdi.Hubs
{
    public class ClothesHub : Hub
    {
        // Отправка обновления одежда всем клиентам
        public async Task SendClothesUpdate(Clothes clothes)
        {
            await Clients.All.SendAsync("ClothesUpdated", clothes);
        }
    }
}

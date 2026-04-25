using Magazin_odejdi.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin_odejdi.Hubs;
using Moq;

namespace Magasin.Test.ClothesHubTests.Hubs
{
    public class ClothesHubTests
    {
        [Fact]
        public async Task SendClothesUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new ClothesHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var clothes = new Clothes
            {
                Naimenovanie = "Лонгслив с надписью",
                Category = "Вверхняя одежда",
                Size = "XL",
                Color = "Коричневый",
                Material = "Хлопок",
                Price = 1249
            };

            // Act
            await hub.SendClothesUpdate(clothes);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "ClothesUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == clothes),
                    default
                ),
                Times.Once
            );
        }
    }
}

using FluentAssertions;
using Magazin_odejdi.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magasin.Test.Pages
{
    public class CreateModelTest
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new Magazin_odejdi.Pages.Clothess.CreateModel(context);

            pageModel.ModelState.AddModelError("Title", "Required");

            // Act
            var result = pageModel.OnPost();

            // Assert
            object value = result.Should().BeOfType<PageResult>();
            context.Clothess.Count().Should().Be(0);
        }
    }
}

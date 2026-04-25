using Magazin_odejdi.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Test_Magazin.Model
{
    public class ClothessTest
    {
        [Fact]
        public void Clothes_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var clothes = new Clothes
            {
                Naimenovanie = "Лонгслив с надписью",
                Category = "Вверхняя одежда",
                Size = "XL",
                Color = "Коричневый",
                Material = "Хлопок",
                Price = 1249,
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(clothes);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(clothes, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если не указать заголовок, то объект будет невалиден.
        [Fact]
        public void Clothes_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var clothes = new Clothes
            {
                Naimenovanie = "Лонгслив",
                Category = "Вверхняя одежда",
                Price = 1200,
            };

            var context = new ValidationContext(clothes);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(clothes, context, results, true);

            // Assert
            //Assert.False(isValid);
            //Assert.Contains(results, r => r.ErrorMessage.Contains("Пожалуйста заполните имя"));
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace Magazin_odejdi.Model
{
    public class Clothes : EFModel
    {
        [ValidateNever]
        [JsonIgnore]
        public string? Naimenovanie { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните поле имя")]
        public string? Category { get; set; }
        public string? Size { get; set; } // размер одежды
        public string? Color { get; set; }
        public string? Material { get; set; }
        public double Price { get; set; }
    }
}

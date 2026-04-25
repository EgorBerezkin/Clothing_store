using System.ComponentModel.DataAnnotations;

namespace Magazin_odejdi.Model
{
    public class Clothes : EFModel
    {
        
        public string? Naimenovanie { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните поле имя")]

        public string? Category { get; set; }
        public string? Size { get; set; } // размер одежды
        public string? Color { get; set; }
        public string? Material { get; set; }
        public double Price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Magazin_odejdi.Model
{
    public class Buyer : EFModel // посетитель
    {
        [Required(ErrorMessage = "Пожалуйста, заполните ФИО")]
        public string? FIO { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле телефон")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле дата рождения")]
        public DateTime Data_BirthDay {  get; set; }

        /*
        public DateTime Data_pokupki { get; set; }
        public double Summ { get; set; }
        */
    }
}

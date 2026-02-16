namespace Magazin_odejdi.Model
{
    public class Buyer : EFModel // посетитель
    {
        public string FIO { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Data_BirthDay {  get; set; }

        /*
        public DateTime Data_pokupki { get; set; }
        public double Summ { get; set; }
        */
    }
}

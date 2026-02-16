namespace Magazin_odejdi.Model
{
    public class Clothes : EFModel
    {
        public string Naimenovanie { get; set; }
        public string Category { get; set; }
        public string Size { get; set; } // размер одежды
        public string Color { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }
    }
}

namespace DataAccessBlazor.Pages.FormsValidation
{
    public enum ShirtColor
    {
        Red, Blue, Yellow, Green, Black, White
    };

    public enum ShirtSize
    {
        Small, Medium, Large, ExtraLarge
    };

    public class Shirt
    {
        public ShirtColor Color { get; set; }
        public ShirtSize Size { get; set; }
        public decimal Price;
    }
}

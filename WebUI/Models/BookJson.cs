namespace WebUI.Models
{
    public class BookJson
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Genre { get; set; }
        public string[] Authors { get; set; }
    }
}
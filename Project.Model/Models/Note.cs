namespace Project.Model.Models
{
    public class Note : BaseEntity
    {
        public string Text   { get; set; }
        public string Colour { get; set; }
        public int Height    { get; set; }
        public int Width     { get; set; }
        public int Left      { get; set; }
        public int Top       { get; set; }

    }
}

using SQLite;

namespace OsoulSunna.Models
{
    [Table("Book")]
    public class Book
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string BookTitle { get; set; }
        public string PageNo { get; set; }
        public string Head { get; set; }
        public string Content1 { get; set; }
        public string Source1 { get; set; }
        public string Content2 { get; set; }
        public string Source2 { get; set; }
        public string Content3 { get; set; }
        public string Source3 { get; set; }
        public string Content4 { get; set; }
        public string Source4 { get; set; }
        public string Content5 { get; set; }
        public string Source5 { get; set; }
    }
}

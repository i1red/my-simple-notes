using SQLite;

namespace MyNotes.Models
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string text { get; set; }
        public bool isFavorite { get; set; }
    }
}

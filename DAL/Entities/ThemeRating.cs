using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ThemeRating
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public Theme Theme { get; set; }
    }
}
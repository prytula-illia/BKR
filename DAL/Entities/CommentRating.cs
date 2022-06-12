using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class CommentRating
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
        public Comment Comment { get; set; }
    }
}
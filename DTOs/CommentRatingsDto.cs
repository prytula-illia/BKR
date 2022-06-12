namespace DTOs
{
    public class CommentRatingsDto
    {
        public string Username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
        public int CommentId { get; set; }
    }
}
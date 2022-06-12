using System;
using System.Collections.Generic;

namespace DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public List<CommentRatingsDto> CommentRatings { get; set; }
    }
}

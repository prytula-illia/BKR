using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public StudyingMaterials StudyingMaterial {get;set; }
        public List<CommentRating> CommentRatings { get; set; }
    }
}

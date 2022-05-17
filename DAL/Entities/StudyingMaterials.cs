using System.Collections.Generic;

namespace DAL.Entities
{
    public class StudyingMaterials
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Theme Theme { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

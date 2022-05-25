using System.Collections.Generic;

namespace DTOs
{
    public class StudyingMaterialsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}

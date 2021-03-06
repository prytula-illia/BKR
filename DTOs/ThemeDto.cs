using System.Collections.Generic;

namespace DTOs
{
    public class ThemeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedByUser { get; set; }
        public List<ThemeRatingDto> ThemeRatings { get; set; }
        public List<StudyingMaterialsDto> StudyingMaterials { get; set; }
        public List<PracticalTaskDto> Tasks { get; set; }
        public int CourseId { get; set; }
    }
}

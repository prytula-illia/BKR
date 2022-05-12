using System.Collections.Generic;

namespace DTOs
{
    public class ThemeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudyingMaterialsDto> StudyingMaterials { get; set; }
        public List<PracticalTaskDto> Tasks { get; set; }
        public int Score { get; set; }
    }
}

using System.Collections.Generic;

namespace DTOs
{
    public class ThemeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudyingMaterialsDto> StudyingMaterials { get; set; }
        public PracticalTaskDto Task { get; set; }

    }
}

using System.Collections.Generic;

namespace DAL.Entities
{
    public class Theme
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudyingMaterials> StudyingMaterials { get; set; }
        public PracticalTask Task { get; set; }

    }
}

using System.Collections.Generic;

namespace DAL.Entities
{
    public class Theme
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudyingMaterials> StudyingMaterials { get; set; }
        public List<PracticalTask> Tasks { get; set; }
        public int Score { get; set; }
    }
}

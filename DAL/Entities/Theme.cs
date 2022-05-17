using System.Collections.Generic;

namespace DAL.Entities
{
    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public List<StudyingMaterials> StudyingMaterials { get; set; }
        public List<PracticalTask> Tasks { get; set; }
        public Course Course { get; set; }
        public List<UserStatistics> Statistics { get; set; }
    }
}

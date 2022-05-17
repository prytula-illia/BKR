using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserStatistics
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public List<Course> FinishedCourses { get; set; }
        public List<Theme> FinishedThemes { get; set; }
    }
}

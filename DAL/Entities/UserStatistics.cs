using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserStatistics
    {
        [Key]
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int Rating { get; set; }
        public List<Course> FinishedCourses { get; set; }
        public List<Theme> FinishedThemes { get; set; }
        public List<PracticalTask> FinishedTasks { get; set; }
    }
}

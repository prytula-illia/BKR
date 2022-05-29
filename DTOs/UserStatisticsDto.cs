using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UserStatisticsDto
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int Rating { get; set; }
        public List<CourseDto> FinishedCourses { get; set; }
        public List<ThemeDto> FinishedThemes { get; set; }
    }
}

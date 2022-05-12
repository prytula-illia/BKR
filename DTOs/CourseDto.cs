using System.Collections.Generic;

namespace DTOs
{
    public class CourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ThemeDto> Themes { get; set; }
    }
}

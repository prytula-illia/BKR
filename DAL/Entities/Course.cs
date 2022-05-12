using System.Collections.Generic;

namespace DAL.Entities
{
    public class Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Theme> Themes { get; set; }
    }
}

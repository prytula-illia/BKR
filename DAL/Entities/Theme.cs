﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudyingMaterials> StudyingMaterials { get; set; }
        public List<PracticalTask> Tasks { get; set; }
    }
}

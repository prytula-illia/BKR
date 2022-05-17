using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public StudyingMaterials StudyingMaterial {get;set;}
    }
}

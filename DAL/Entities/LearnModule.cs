using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LearnModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubmodulesCount { get; set; }
    }
}

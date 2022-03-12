using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class LearnModuleRepository : IRepository<LearnModule>
    {

        private static readonly string[] Modules = new[]
        {
            "C#", "Java", "Python", "C", "C++", "Golang", "Algoritms"
        };

        // just to avoid db connection by now
        public IEnumerable<LearnModule> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new LearnModule
            {
                Name = Modules[rng.Next(Modules.Length)],
                Description = "Some description",
                SubmodulesCount = rng.Next(2, 10)
            })
            .ToArray();
        }
    }
}

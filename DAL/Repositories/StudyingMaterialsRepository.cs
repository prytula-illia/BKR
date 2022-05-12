using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class StudyingMaterialsRepository : IStudyingMaterialsRepository
    {
        public void Create(StudyingMaterials entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StudyingMaterials Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudyingMaterials> GetAll()
        {
            // Just to check swagger enpoint
            return new List<StudyingMaterials>()
            {
                new()
                {
                    Title = "Something",
                    Content = "Something content"
                }
            };
        }

        public void Update(StudyingMaterials entity)
        {
            throw new NotImplementedException();
        }
    }
}

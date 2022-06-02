using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudyingMaterialsRepository : IRepository<StudyingMaterials>
    {
        public Task<StudyingMaterials> GetWithNestedData(int studyingMaterialId);
    }
}

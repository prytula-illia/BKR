using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StudyingMaterialsRepository : BaseRepository<StudyingMaterials>, IStudyingMaterialsRepository
    {
        public StudyingMaterialsRepository(Context context) : base(context)
        {
        }
    }
}

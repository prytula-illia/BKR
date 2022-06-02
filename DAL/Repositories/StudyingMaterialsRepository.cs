using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudyingMaterialsRepository : BaseRepository<StudyingMaterials>, IStudyingMaterialsRepository
    {
        public StudyingMaterialsRepository(Context context) : base(context)
        {
        }

        public async Task<StudyingMaterials> GetWithNestedData(int studyingMaterialId)
        {
            var result = await _context.StudyingMaterials.Where(x => x.Id == studyingMaterialId)
                 .Include(x => x.Comments)
                 .AsSplitQuery()
                 .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}

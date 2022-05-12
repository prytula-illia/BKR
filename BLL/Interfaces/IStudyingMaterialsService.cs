using DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IStudyingMaterialsService
    {
        public IEnumerable<StudyingMaterialsDto> GetAllStudyingMaterials();
    }
}

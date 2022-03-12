using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ILearnModuleService
    {
        public IEnumerable<LearnModuleDto> GetAllLearnModules();
    }
}

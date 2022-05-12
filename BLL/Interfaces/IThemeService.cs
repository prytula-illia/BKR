using DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IThemeService : ICrudService<ThemeDto>
    {
        public IEnumerable<ThemeDto> SearchThemes(string themeName);
    }
}

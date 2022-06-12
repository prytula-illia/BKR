using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IThemeService : ICrudService<ThemeDto>
    {
        public IEnumerable<ThemeDto> SearchThemes(string themeName);
        public Task<IEnumerable<ThemeDto>> GetCourseThemes(int id);
        public Task<int> CreateThemeForCourse(ThemeDto dto, int courseId);
        Task UpdateRating(ThemeRatingDto dto);
    }
}

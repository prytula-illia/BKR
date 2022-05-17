using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _repository;
        private readonly IMapper _mapper;

        public ThemeService(IThemeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            var result = await _repository.Create(theme);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteThemeWithData(id);
        }

        public async Task<ThemeDto> Get(int id)
        {
            var theme = await _repository.Get(id);

            return _mapper.Map<ThemeDto>(theme);
        }

        public IEnumerable<ThemeDto> GetAll()
        {
            var themes = _repository.GetAll();

            return _mapper.Map<IEnumerable<ThemeDto>>(themes);
        }

        public async Task Update(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            await _repository.Update(theme);
        }

        public IEnumerable<ThemeDto> SearchThemes(string themeName)
        {
            return GetAll().Where(x => x.Title.Contains(themeName));
        }
    }
}

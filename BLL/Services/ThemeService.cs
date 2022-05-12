using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            _repository.Create(theme);
        }

        public void Delete(int id)
        {
            _repository.DeleteThemeWithData(id);
        }

        public ThemeDto Get(int id)
        {
            var theme = _repository.Get(id);

            return _mapper.Map<ThemeDto>(theme);
        }

        public IEnumerable<ThemeDto> GetAll()
        {
            var themes = _repository.GetAll();

            return _mapper.Map<IEnumerable<ThemeDto>>(themes);
        }

        public void Update(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            _repository.Update(theme);
        }

        public IEnumerable<ThemeDto> SearchThemes(string themeName)
        {
            return GetAll().Where(x => x.Title.Contains(themeName));
        }
    }
}

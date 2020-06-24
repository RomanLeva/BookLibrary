using DataAccess.Dto;
using System.Collections.Generic;

namespace DataAccess.Services
{
    public interface IGenreService
    {
        List<GenreDto> GetAll();

        GenreDto GetById(int genreId);
    }
}

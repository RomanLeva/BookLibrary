using BusinessLogic.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IGenreService
    {
        List<GenreDto> GetAll();
        GenreDto GetById(int genreId);
    }
}

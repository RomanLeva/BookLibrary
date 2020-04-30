using BusinessLogic.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IGenreService
    {
        List<GenreDTO> GetAll();
        GenreDTO GetOne(int id);
        List<GenreDTO> Find(Func<GenreDTO, bool> predicate);
        void Create(GenreDTO item);
        void Update(GenreDTO item);
        void Delete(int id);
    }
}

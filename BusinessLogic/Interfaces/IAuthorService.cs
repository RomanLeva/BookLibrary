using BusinessLogic.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDTO> GetAll();
        AuthorDTO GetOne(int id);
        List<AuthorDTO> Find(Func<AuthorDTO, bool> predicate);
        void Create(AuthorDTO item);
        void Update(AuthorDTO item);
        void Delete(int id);
    }
}

using DataAccess.Dto;
using System.Collections.Generic;

namespace DataAccess.Services
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAll();

        AuthorDto GetById(int authorId);
    }
}

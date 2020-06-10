using BusinessLogic.Dto;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAll();
        AuthorDto GetById(int authorId);
    }
}

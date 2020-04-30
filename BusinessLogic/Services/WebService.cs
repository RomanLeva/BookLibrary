using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class WebService : IWebService
    {
        private IMapper mapper;
        private IBookRepository bookRep;
        private IGenreRepository genreRep;
        private IAuthorRepository authorRep;

        public WebService(IBookRepository bookRep, IGenreRepository genreRep, IAuthorRepository authorRep, IMapper mapper)
        {
            this.mapper = mapper;
            this.bookRep = bookRep;
            this.authorRep = authorRep;
            this.genreRep = genreRep;
        }

        public List<BookDTO> GetBooks()
        {
            var objects = bookRep.GetAll();
            return mapper.Map<List<BookDTO>>(objects);
        }
        public List<AuthorDTO> GetAuthors()
        {
            var objects = authorRep.GetAll();
            return mapper.Map<List<AuthorDTO>>(objects);
        }
        public List<GenreDTO> GetGenres()
        {
            var objects = genreRep.GetAll();
            return mapper.Map<List<GenreDTO>>(objects);
        }
        public string GetBookStat(int id)
        {
            var book = bookRep.Get(id);
            if (book != null && book.Text != null)
            {
                string text = book.Text;
                StringBuilder sb = new StringBuilder();
                sb.Append("Text length: ").Append(BookStatUtils.TextLength(text)).AppendLine();
                sb.Append("Words count: ").Append(BookStatUtils.WordsCount(text)).AppendLine();
                sb.Append("Unique words: ").Append(BookStatUtils.UniqueWordsCount(text)).AppendLine();
                sb.Append("Middle word length: ").Append(BookStatUtils.MiddleWordLegth(text)).AppendLine();
                sb.Append("Middle sentence length: ").Append(BookStatUtils.MiddleSentenceLength(text)).AppendLine();
                return sb.ToString();
            }
            else return "";
        }

        public BookDTO GetBook(int id)
        {
            var obj = bookRep.Get(id);
            return mapper.Map<BookDTO>(obj);
        }

        public void CreateOrUpdateBook(BookDTO book)
        {
            var obj = mapper.Map<Book>(book);
        }
    }
}

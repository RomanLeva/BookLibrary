﻿using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Mappings;
using BusinessLogic.Interfaces;
using DataAccess.Abstract;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class WebApiService : IWebApiService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRep;
        private readonly IGenreRepository _genreRep;
        private readonly IAuthorRepository _authorRep;

        public WebApiService(IBookRepository bookRep, IGenreRepository genreRep, IAuthorRepository authorRep, IMapper mapper)
        {
            _mapper = mapper;
            _bookRep = bookRep;
            _authorRep = authorRep;
            _genreRep = genreRep;
        }

        public List<BookDto> GetBooks()
        {
            var objects = _bookRep.GetAll();
            return _mapper.Map<List<BookDto>>(objects);
        }
        public List<AuthorDto> GetAuthors()
        {
            var objects = _authorRep.GetAll();
            return _mapper.Map<List<AuthorDto>>(objects);
        }
        public List<GenreDto> GetGenres()
        {
            var objects = _genreRep.GetAll();
            return _mapper.Map<List<GenreDto>>(objects);
        }
        public string GetBookStat(int id)
        {
            var book = _bookRep.Get(id);

            if (book != null && book.Text != null)
            {
                string text = book.Text;

                StringBuilder sb = new StringBuilder();
                sb.Append("Text length: ").Append(TextStatisticsUtils.TextLength(text)).AppendLine();
                sb.Append("Words count: ").Append(TextStatisticsUtils.WordsCount(text)).AppendLine();
                sb.Append("Unique words: ").Append(TextStatisticsUtils.UniqueWordsCount(text)).AppendLine();
                sb.Append("Middle word length: ").Append(TextStatisticsUtils.AverageWordLegth(text)).AppendLine();
                sb.Append("Middle sentence length: ").Append(TextStatisticsUtils.MiddleSentenceLength(text)).AppendLine();

                return sb.ToString();
            }
            else return "";
        }

        public BookDto GetBook(int id)
        {
            var obj = _bookRep.Get(id);
            return _mapper.Map<BookDto>(obj);
        }

        public void CreateOrUpdateBook(BookDto book)
        {
            //var obj = _mapper.Map<Book>(book);
        }

        public void DeleteBook(int id)
        {
            _bookRep.Delete(id);
        }
    }
}
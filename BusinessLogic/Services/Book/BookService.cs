using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Mappings;
using BusinessLogic.Interfaces;
using DataAccess.Abstract;
using DataAccess.Entities;
using System;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(BookDto bookDto,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile)
        {
            if (imageFile != null)
            {
                var image = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(image, 0, imageFile.ContentLength);

                var path = HttpContext.Current.Server.MapPath(@"/images/books/" + bookDto.Name + ".jpg");
                System.IO.File.WriteAllBytes(path, image);

                bookDto.ImageUrl = "/images/books/" + bookDto.Name + ".jpg";
            }

            if (textFile != null)
            {
                bookDto.Text = new StreamReader(textFile.InputStream).ReadToEnd();
            }

            var bookObj = _mapper.Map<Book>(bookDto);
            
            _repository.Create(bookObj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<BookDto> Find(Func<BookDto, bool> predicate)
        {
            var objects = _repository.GetAll();
            var dtos = _mapper.Map<List<BookDto>>(objects);
            var entities = new List<Book>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(_mapper.Map<Book>(b));
                }
            }
            var e = _mapper.Map<List<BookDto>>(entities);
            return e;
        }

        public void Update(BookDto bookDto,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile)
        {
            if (imageFile != null)
            {
                var image = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(image, 0, imageFile.ContentLength);

                var path = HttpContext.Current.Server.MapPath(@"/images/books/" + bookDto.Name + ".jpg");
                System.IO.File.WriteAllBytes(path, image);

                bookDto.ImageUrl = "/images/books/" + bookDto.Name + ".jpg";
            }
            if (textFile != null)
            {
                bookDto.Text = new StreamReader(textFile.InputStream).ReadToEnd();
            }
            var bookObj = _mapper.Map<Book>(bookDto);
            _repository.Update(bookObj);
        }

        List<BookDto> IBookService.GetAll()
        {
            var objects = _repository.GetAll();
            return _mapper.Map<List<BookDto>>(objects);
        }

        BookDto IBookService.GetById(int bookId)
        {
            var obj = _repository.Get(bookId);
            return _mapper.Map<BookDto>(obj);
        }

        public List<BookDto> Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var books = _repository.Search(BookName,AuthorName,Genre,Date);
            return _mapper.Map<List<BookDto>>(books);
        }
        public async Task FillStorageWithFakeBooks()
        {
            await Task.Run(() => TableGenerator.FillStorageWithFakeBooks(10000, 100, 10));
        }
    }
}

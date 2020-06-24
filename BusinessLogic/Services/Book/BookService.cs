using AutoMapper;
using DataAccess.Dto;
using DataAccess.Repositories;
using System.Web;
using System.Collections.Generic;
using System.IO;
using DataAccess.Infrastructore;
using System;

namespace DataAccess.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _IBookRepository;
        private readonly IMapper _mapper;
        private readonly SqlBulkCopyFasade _sqlBulkCopyFasade;

        public BookService(IBookRepository repository, IMapper mapper, SqlBulkCopyFasade sqlBulkCopyFasade)
        {
            _IBookRepository = repository;
            _mapper = mapper;
            _sqlBulkCopyFasade = sqlBulkCopyFasade;
        }

        public void Create(
            BookDto bookDto,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile)
        {
            if (imageFile != null)
            {
                var image = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(image, 0, imageFile.ContentLength);

                var path = HttpContext.Current.Server.MapPath(@"/images/books/" + bookDto.Name + ".jpg");
                File.WriteAllBytes(path, image);

                bookDto.ImageUrl = "/images/books/" + bookDto.Name + ".jpg";
            } else
            {
                bookDto.ImageUrl = "~\\images\\book_image.jpg";
            }

            if (textFile != null)
            {
                bookDto.Text = new StreamReader(textFile.InputStream).ReadToEnd();
            }

            CalculateBookStatistics(bookDto);

            var bookObj = _mapper.Map<Book>(bookDto);
            
            _IBookRepository.Create(bookObj);
        }

        public void Delete(int bookId)
        {
            _IBookRepository.Delete(bookId);
        }

        public void Update(
            BookDto bookDto,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile)
        {
            if (imageFile != null)
            {
                var image = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(image, 0, imageFile.ContentLength);

                var path = HttpContext.Current.Server.MapPath(@"/images/books/" + bookDto.Name + ".jpg");
                File.WriteAllBytes(path, image);

                bookDto.ImageUrl = "/images/books/" + bookDto.Name + ".jpg";
            }else
            {
                bookDto.ImageUrl = "~\\images\\book_image.jpg";
            }

            if (textFile != null)
            {
                bookDto.Text = new StreamReader(textFile.InputStream).ReadToEnd();
            }

            CalculateBookStatistics(bookDto);

            var bookObj = _mapper.Map<Book>(bookDto);

            _IBookRepository.Update(bookObj);
        }

        List<BookDto> IBookService.GetAll()
        {
            var books = _IBookRepository.GetAll();
            return _mapper.Map<List<BookDto>>(books);
        }

        BookDto IBookService.GetById(int bookId)
        {
            var book = _IBookRepository.Get(bookId);
            return _mapper.Map<BookDto>(book);
        }

        public List<BookDto> Search(string bookName, string authorName, string genre, string date)
        {
            var books = _IBookRepository.Search(bookName, authorName, genre, date);
            return _mapper.Map<List<BookDto>>(books);
        }

        public void FillStorageWithFakeBooks()
        {
            const int booksIdCount = 10000;
            const int authorsIdCount = 1000;
            const int genresIdCount = 100;

            var tableGenerator = new TableGenerator();

            var booksTable = tableGenerator.CreateBooksTable(booksIdCount);
            var authorsTable = tableGenerator.CreateAuthorsTable(authorsIdCount);
            var genresTable = tableGenerator.CreateGenresTable(genresIdCount);
            var bookToAuthorstable = tableGenerator.CreateBookAuthorsTable(booksIdCount, genresIdCount);
            var genreToBookstable = tableGenerator.CreateGenreBooksTable(genresIdCount, booksIdCount);

            _sqlBulkCopyFasade.WriteDataTableToServer(booksTable);
            _sqlBulkCopyFasade.WriteDataTableToServer(authorsTable);
            _sqlBulkCopyFasade.WriteDataTableToServer(genresTable);
            _sqlBulkCopyFasade.WriteDataTableToServer(bookToAuthorstable);
            _sqlBulkCopyFasade.WriteDataTableToServer(genreToBookstable);
        }

        private void CalculateBookStatistics(BookDto bookDto)
        {
            var textStatistic = new BookTextStatisticDto();
            textStatistic.WordsCount = TextStatisticsUtils.WordsCount(bookDto.Text);
            textStatistic.AverageSentenceLenght = Convert.ToInt32(TextStatisticsUtils.AverageSentenceLength(bookDto.Text));
            textStatistic.AverageWordLenght = Convert.ToInt32(TextStatisticsUtils.AverageWordLength(bookDto.Text));
            textStatistic.UniqueWords = TextStatisticsUtils.UniqueWordsCount(bookDto.Text);
            textStatistic.TextLength = TextStatisticsUtils.TextLength(bookDto.Text);

            bookDto.TextStatistics.Add(textStatistic);
        }
    }
}

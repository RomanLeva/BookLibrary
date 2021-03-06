﻿using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;
using DataAccess.EntityFramework;

namespace DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EFDBContext _context;
        static GenreRepository()
        {
            // the terrible hack, force downloading dll
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public GenreRepository(EFDBContext dbContext)
        {
            _context = dbContext;
        }

        public Genre Get(int genreId)
        {
            return _context.Genres.Where(x => x.GenreId == genreId).FirstOrDefault();
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}

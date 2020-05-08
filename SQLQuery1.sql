delete from books;
delete from authors;
delete from genres;
DBCC CHECKIDENT ('[books]', RESEED, 0);
DBCC CHECKIDENT ('[authors]', RESEED, 0);
DBCC CHECKIDENT ('[genres]', RESEED, 0);
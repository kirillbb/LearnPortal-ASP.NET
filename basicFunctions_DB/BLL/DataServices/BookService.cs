using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.BLL.Interfaces;
using basicFunctions_DB.DAL;
using basicFunctions_DB.DAL.MaterialType;
using Microsoft.EntityFrameworkCore;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class BookService : IBookService
    {
        private readonly ApplicationContext _context;

        public BookService(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(BookDTO bookDTO)
        {
            await this._context.Materials.AddAsync(new Book
            {
                Title = bookDTO.Title,
                Creator = bookDTO.Creator,
                Pages = bookDTO.Pages,
                BookFormat = bookDTO.BookFormat,
                Author = bookDTO.Author,
                PublicationDate = bookDTO.PublicationDate
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            var books = await this._context.Books.Include(x => x.Creator).ToListAsync();
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (var item in books)
            {
                BookDTO bookDTO = new BookDTO
                {
                    Title = item.Title,
                    Creator = item.Creator,
                    Pages = item.Pages,
                    BookFormat = item.BookFormat,
                    Author = item.Author,
                    PublicationDate = item.PublicationDate,
                    Id = item.Id
                };

                bookDTOs.Add(bookDTO);
            }

            return bookDTOs;
        }

        public async Task<BookDTO?> GetAsync(int id)
        {
            var book = await this._context.Books.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);
            BookDTO bookDTO = null;

            if (book != null)
            {
                bookDTO = new BookDTO
                {
                    Title = book.Title,
                    Creator = book.Creator,
                    PublicationDate = book.PublicationDate,
                    Author = book.Author,
                    Pages = book.Pages,
                    BookFormat = book.BookFormat,
                    Id = book.Id
                };

                return bookDTO;
            }
            else
            {
                return bookDTO;
            }
        }

        public async Task UpdateAsync(BookDTO bookDTO)
        {
            var book = await this._context.Books.FirstOrDefaultAsync(x => x.Id == bookDTO.Id);

            if (book != null)
            {
                book.Title = bookDTO.Title;
                book.Creator = bookDTO.Creator;
                book.Pages = bookDTO.Pages;
                book.BookFormat = bookDTO.BookFormat;
                book.Author = bookDTO.Author;
                book.PublicationDate = bookDTO.PublicationDate;

                await this._context.SaveChangesAsync();
            }
        }
    }
}

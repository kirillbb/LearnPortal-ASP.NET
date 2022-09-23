namespace LearnPortalASP.BLL.DataServices
{
    using LearnPortalASP.BLL.DTO;
    using LearnPortalASP.BLL.Interfaces;
    using LearnPortalASP.Data;
    using LearnPortalASP.Models.MaterialType;
    using Microsoft.EntityFrameworkCore;

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
                CreatorUserName = bookDTO.CreatorUserName,
                Pages = bookDTO.Pages,
                BookFormat = bookDTO.BookFormat,
                Author = bookDTO.Author,
                PublicationDate = bookDTO.PublicationDate
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            var books = await this._context.Books.ToListAsync();
            List<BookDTO> bookDTOs = new List<BookDTO>();

            foreach (var item in books)
            {
                BookDTO bookDTO = new BookDTO
                {
                    Title = item.Title,
                    CreatorUserName = item.CreatorUserName,
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

        public async Task<BookDTO?> GetAsync(int? id)
        {
            var bookDTO = await this._context.Books
                .Select(book => new BookDTO
                {
                    Title = book.Title,
                    CreatorUserName = book.CreatorUserName,
                    PublicationDate = book.PublicationDate,
                    Author = book.Author,
                    Pages = book.Pages,
                    BookFormat = book.BookFormat,
                    Id = book.Id
                })
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return bookDTO;
        }

        public async Task UpdateAsync(BookDTO bookDTO)
        {
            var book = await this._context.Books
                .FirstOrDefaultAsync(x => x.Id == bookDTO.Id);

            if (book != null)
            {
                book.Title = bookDTO.Title;
                book.CreatorUserName = bookDTO.CreatorUserName;
                book.Pages = bookDTO.Pages;
                book.BookFormat = bookDTO.BookFormat;
                book.Author = bookDTO.Author;
                book.PublicationDate = bookDTO.PublicationDate;

                this._context.Books.Update(book);
                await this._context.SaveChangesAsync();
            }
        }
    }
}

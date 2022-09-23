using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.BLL.Interfaces
{
    internal interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();

        Task UpdateAsync(BookDTO bookDTO);

        Task<BookDTO?> GetAsync(int? id);

        Task CreateAsync(BookDTO bookDTO);
    }
}

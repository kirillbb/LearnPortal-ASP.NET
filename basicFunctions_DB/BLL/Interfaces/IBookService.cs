using basicFunctions_DB.BLL.DTO;

namespace basicFunctions_DB.BLL.Interfaces
{
    internal interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();
        Task UpdateAsync(BookDTO bookDTO);
        Task<BookDTO?> GetAsync(int id);
        Task CreateAsync(BookDTO bookDTO);
    }
}

namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.BLL.DTO;

    internal interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();

        Task UpdateAsync(BookDTO bookDTO);

        Task<BookDTO?> GetAsync(int? id);

        Task CreateAsync(BookDTO bookDTO);
    }
}

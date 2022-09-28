namespace basicFunctions_DB.BLL.Interfaces
{
    using basicFunctions_DB.BLL.DTO;

    internal interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();

        Task UpdateAsync(BookDTO bookDTO);

        Task<BookDTO?> GetAsync(int id);

        Task CreateAsync(BookDTO bookDTO);
    }
}

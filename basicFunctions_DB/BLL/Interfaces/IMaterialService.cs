namespace basicFunctions_DB.BLL.Interfaces
{
    using basicFunctions_DB.BLL.DTO;

    internal interface IMaterialService
    {
        Task<List<MaterialDTO>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
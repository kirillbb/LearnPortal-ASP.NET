using basicFunctions_DB.BLL.DTO;

namespace basicFunctions_DB.BLL.Interfaces
{
    internal interface IMaterialService
    {
        Task<List<MaterialDTO>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
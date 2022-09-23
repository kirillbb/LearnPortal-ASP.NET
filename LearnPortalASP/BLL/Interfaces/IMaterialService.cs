using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.BLL.Interfaces
{
    internal interface IMaterialService
    {
        Task<List<MaterialDTO>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
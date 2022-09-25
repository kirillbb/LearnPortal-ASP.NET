namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.BLL.DTO;

    internal interface IMaterialService
    {
        Task<List<MaterialDTO>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
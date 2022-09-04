using basicFunctions_DB.BLL.DTO;

namespace basicFunctions_DB.BLL.Interfaces
{
    internal interface ISkillService
    {
        Task DeleteAsync(int id);

        Task<List<SkillDTO>> GetAllAsync();

        Task UpdateAsync(SkillDTO skillDTO);

        Task<SkillDTO?> GetAsync(int id);

        Task CreateAsync(SkillDTO skillDTO);
    }
}

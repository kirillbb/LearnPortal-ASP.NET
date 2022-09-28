namespace basicFunctions_DB.BLL.Interfaces
{
    using basicFunctions_DB.BLL.DTO;

    internal interface ISkillService
    {
        Task DeleteAsync(int id);

        Task<List<SkillDTO>> GetAllAsync();

        Task UpdateAsync(SkillDTO skillDTO);

        Task<SkillDTO?> GetAsync(int id);

        Task CreateAsync(SkillDTO skillDTO);
    }
}

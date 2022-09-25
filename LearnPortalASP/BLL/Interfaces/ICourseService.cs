namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.BLL.DTO;

    public interface ICourseService
    {
        Task DeleteAsync(int? id);

        Task<List<CourseDTO>> GetAllAsync();

        Task UpdateAsync(CourseDTO courseDTO);

        Task<CourseDTO?> GetAsync(int? id);

        Task CreateAsync(CourseDTO courseDTO);
    }
}

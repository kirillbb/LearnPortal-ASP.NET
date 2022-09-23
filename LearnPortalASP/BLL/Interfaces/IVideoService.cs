using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.BLL.Interfaces
{
    internal interface IVideoService
    {
        Task<List<VideoDTO>> GetAllAsync();

        Task UpdateAsync(VideoDTO videoDTO);

        Task<VideoDTO?> GetAsync(int id);

        Task CreateAsync(VideoDTO videoDTO);
    }
}
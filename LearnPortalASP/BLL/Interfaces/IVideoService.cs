namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.BLL.DTO;

    internal interface IVideoService
    {
        Task<List<VideoDTO>> GetAllAsync();

        Task UpdateAsync(VideoDTO videoDTO);

        Task<VideoDTO?> GetAsync(int? id);

        Task CreateAsync(VideoDTO videoDTO);
    }
}
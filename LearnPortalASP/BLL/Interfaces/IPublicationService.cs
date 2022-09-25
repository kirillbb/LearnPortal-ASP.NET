using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.BLL.Interfaces
{
    internal interface IPublicationService
    {
        Task<List<PublicationDTO>> GetAllAsync();

        Task UpdateAsync(PublicationDTO publicationDTO);

        Task<PublicationDTO?> GetAsync(int? id);

        Task CreateAsync(PublicationDTO publicationDTO);
    }
}
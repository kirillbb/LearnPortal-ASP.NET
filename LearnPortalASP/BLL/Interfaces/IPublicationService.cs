namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.BLL.DTO;

    internal interface IPublicationService
    {
        Task<List<PublicationDTO>> GetAllAsync();

        Task UpdateAsync(PublicationDTO publicationDTO);

        Task<PublicationDTO?> GetAsync(int? id);

        Task CreateAsync(PublicationDTO publicationDTO);
    }
}
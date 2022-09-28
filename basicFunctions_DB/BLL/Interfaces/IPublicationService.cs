namespace basicFunctions_DB.BLL.Interfaces
{
    using basicFunctions_DB.BLL.DTO;

    internal interface IPublicationService
    {
        Task<List<PublicationDTO>> GetAllAsync();

        Task UpdateAsync(PublicationDTO publicationDTO);

        Task<PublicationDTO?> GetAsync(int id);

        Task CreateAsync(PublicationDTO publicationDTO);
    }
}
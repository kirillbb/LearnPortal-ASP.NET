using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.DAL.MaterialType;

namespace basicFunctions_DB.BLL.Interfaces
{
    internal interface IPublicationService
    {
        Task<List<PublicationDTO>> GetAllAsync();
        Task UpdateAsync(PublicationDTO publicationDTO);
        Task<PublicationDTO?> GetAsync(int id);
        Task CreateAsync(PublicationDTO publicationDTO);
    }
}
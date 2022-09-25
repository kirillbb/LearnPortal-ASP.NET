using LearnPortalASP.BLL.DTO;
using LearnPortalASP.BLL.Interfaces;
using LearnPortalASP.Data;
using LearnPortalASP.Models.MaterialType;
using Microsoft.EntityFrameworkCore;

namespace LearnPortalASP.BLL.DataServices
{
    internal class PublicationService : IPublicationService
    {
        private readonly ApplicationContext _context;

        public PublicationService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(PublicationDTO publicationDTO)
        {
            await this._context.Materials.AddAsync(new Publication
            {
                Title = publicationDTO.Title,
                CreationDate = publicationDTO.CreationDate,
                CreatorUserName = publicationDTO.CreatorUserName,
                Source = publicationDTO.Source
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<List<PublicationDTO>> GetAllAsync()
        {
            var publications = await this._context.Publications.ToListAsync();
            List<PublicationDTO> publicationDTOs = new List<PublicationDTO>();
            foreach (var item in publications)
            {
                PublicationDTO publicationDTO = new PublicationDTO
                {
                    CreationDate = item.CreationDate,
                    CreatorUserName = item.CreatorUserName,
                    Id = item.Id,
                    Source = item.Source,
                    Title = item.Title
                };

                publicationDTOs.Add(publicationDTO);
            }

            return publicationDTOs;
        }

        public async Task<PublicationDTO?> GetAsync(int? id)
        {
            var publication = await this._context.Publications.FirstOrDefaultAsync(x => x.Id == id);
            PublicationDTO publicationDTO = null;

            if (publication != null)
            {
                publicationDTO = new PublicationDTO
                {
                    Title = publication.Title,
                    CreatorUserName = publication.CreatorUserName,
                    CreationDate = publication.CreationDate,
                    Source = publication.Source,
                    Id = publication.Id
                };

                return publicationDTO;
            }
            else
            {
                return publicationDTO;
            }
        }

        public async Task UpdateAsync(PublicationDTO publicationDTO)
        {
            var publication = await this._context.Publications.FirstOrDefaultAsync(x => x.Id == publicationDTO.Id);

            if (publication != null)
            {
                publication.Title = publicationDTO.Title;
                publication.CreatorUserName = publicationDTO.CreatorUserName;
                publication.CreationDate = publicationDTO.CreationDate;
                publication.Source = publicationDTO.Source;

                await this._context.SaveChangesAsync();
            }
        }
    }
}

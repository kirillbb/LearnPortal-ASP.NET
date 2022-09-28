namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.BLL.Interfaces;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.MaterialType;
    using Microsoft.EntityFrameworkCore;

    internal class PublicationService : IPublicationService
    {
        private readonly ApplicationContext _context;

        public PublicationService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PublicationDTO publicationDTO)
        {
            await _context.Materials.AddAsync(new Publication
            {
                Title = publicationDTO.Title,
                CreationDate = publicationDTO.CreationDate,
                Creator = publicationDTO.Creator,
                Source = publicationDTO.Source
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<PublicationDTO>> GetAllAsync()
        {
            var publications = await _context.Publications.Include(x => x.Creator).ToListAsync();
            List<PublicationDTO> publicationDTOs = new List<PublicationDTO>();
            foreach (var item in publications)
            {
                PublicationDTO publicationDTO = new PublicationDTO
                {
                    CreationDate = item.CreationDate,
                    Creator = item.Creator,
                    Id = item.Id,
                    Source = item.Source,
                    Title = item.Title
                };

                publicationDTOs.Add(publicationDTO);
            }

            return publicationDTOs;
        }

        public async Task<PublicationDTO?> GetAsync(int id)
        {
            var publication = await _context.Publications.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);
            PublicationDTO publicationDTO = null;

            if (publication != null)
            {
                publicationDTO = new PublicationDTO
                {
                    Title = publication.Title,
                    Creator = publication.Creator,
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
            var publication = await _context.Publications.FirstOrDefaultAsync(x => x.Id == publicationDTO.Id);

            if (publication != null)
            {
                publication.Title = publicationDTO.Title;
                publication.Creator = publicationDTO.Creator;
                publication.CreationDate = publicationDTO.CreationDate;
                publication.Source = publicationDTO.Source;

                await _context.SaveChangesAsync();
            }
        }
    }
}

namespace LearnPortalASP.BLL.DataServices
{
    using LearnPortalASP.BLL.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using LearnPortalASP.BLL.DTO;
    using LearnPortalASP.Models.MaterialType;
    using LearnPortalASP.Data;

    public class MaterialService : IMaterialService
    {
        private readonly ApplicationContext _context;

        public MaterialService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(MaterialDTO materialDTO)
        {
            await this._context.Materials.AddAsync(new Material
            {
                Title = materialDTO.Title,
                CreatorUserName = materialDTO.CreatorUserName,
                Discriminator = materialDTO.Discriminator
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<MaterialDTO?> GetAsync(int? id)
        {
            var materialDTO = await this._context.Materials
                .Select(x => new MaterialDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreatorUserName = x.CreatorUserName,
                    Discriminator= x.Discriminator
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return materialDTO;
        }
        public async Task<List<MaterialDTO>> GetAllAsync()
        {
            var materials = await this._context.Materials.ToListAsync();
            List<MaterialDTO> materialDTOs = new List<MaterialDTO>();

            foreach (var item in materials)
            {
                MaterialDTO materialDTO = new MaterialDTO
                {
                    Id = item.Id,
                    CreatorUserName = item.CreatorUserName,
                    Title = item.Title,
                    Discriminator = item.Discriminator
                };

                materialDTOs.Add(materialDTO);
            }

            return materialDTOs;
        }

        public async Task DeleteAsync(int id)
        {
            var material = await this._context.Materials.FirstOrDefaultAsync(x => x.Id == id);

            if (material != null)
            {
                this._context.Remove(material);
                await this._context.SaveChangesAsync();
            }
        }
    }
}

namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.BLL.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.DAL.MaterialType;

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
                    Title = item.Title
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

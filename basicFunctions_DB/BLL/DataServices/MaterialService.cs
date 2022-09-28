namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.BLL.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using basicFunctions_DB.BLL.DTO;

    internal class MaterialService : IMaterialService
    {
        private readonly ApplicationContext _context;

        public MaterialService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<List<MaterialDTO>> GetAllAsync()
        {
            var materials = await this._context.Materials.Include(x => x.Creator).ToListAsync();
            List<MaterialDTO> materialDTOs = new List<MaterialDTO>();

            foreach (var item in materials)
            {
                MaterialDTO materialDTO = new MaterialDTO
                {
                    Id = item.Id,
                    Creator = item.Creator,
                    Title = item.Title
                };

                materialDTOs.Add(materialDTO);
            }

            return materialDTOs;
        }

        public async Task DeleteAsync(int id)
        {
            var material = await this._context.Materials.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);

            if (material != null)
            {
                this._context.Remove(material);
                await this._context.SaveChangesAsync();
            }
        }
    }
}

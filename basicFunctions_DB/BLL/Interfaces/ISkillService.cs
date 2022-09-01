using basicFunctions_DB.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicFunctions_DB.BLL.Interfaces
{
    internal interface ISkillService
    {
        Task DeleteAsync(int id);
        Task<List<SkillDTO>> GetAllAsync();
        Task UpdateAsync(SkillDTO skillDTO);
        Task<SkillDTO?> GetAsync(int id);
        Task CreateAsync(SkillDTO skillDTO);
    }
}

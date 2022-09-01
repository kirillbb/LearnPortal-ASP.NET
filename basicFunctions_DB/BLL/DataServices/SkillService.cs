using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.BLL.Interfaces;
using basicFunctions_DB.DAL;
using basicFunctions_DB.DAL.CourseType;
using Microsoft.EntityFrameworkCore;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class SkillService : ISkillService
    {
        private readonly ApplicationContext _context;

        public SkillService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(SkillDTO skillDTO)
        {
            await this._context.Skills.AddAsync(new Skill
            {
                Name = skillDTO.Name,
                Description = skillDTO.Description
            });

            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var skill = await this._context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);

            if (skill != null)
            {
                this._context.Remove(skill);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            var skills = await this._context.Skills.ToListAsync();
            List<SkillDTO> skillDTOs = new List<SkillDTO>();
            foreach (var item in skills)
            {
                SkillDTO skillDTO = new SkillDTO
                {
                    Name = item.Name,
                    Description = item.Description,
                    Id = item.Id
                };

                skillDTOs.Add(skillDTO);
            }

            return skillDTOs;
        }

        public async Task<SkillDTO?> GetAsync(int id)
        {
            var skill = await this._context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);
            SkillDTO skillDTO = null;

            if (skill != null)
            {
                skillDTO = new SkillDTO
                {
                    Name = skill.Name,
                    Description = skill.Description,
                    Id = skill.Id
                };

                return skillDTO;
            }
            else
            {
                return skillDTO;
            }
        }

        public async Task UpdateAsync(SkillDTO skillDTO)
        {
            var skill = await this._context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == skillDTO.Id);

            if (skill != null)
            {
                skill.Name = skillDTO.Name;
                skill.Description = skillDTO.Description;
                await this._context.SaveChangesAsync();
            }
        }
    }
}

namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.BLL.Interfaces;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.CourseType;
    using Microsoft.EntityFrameworkCore;

    internal class SkillService : ISkillService
    {
        private readonly ApplicationContext _context;

        public SkillService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SkillDTO skillDTO)
        {
            await _context.Skills.AddAsync(new Skill
            {
                Name = skillDTO.Name,
                Description = skillDTO.Description
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var skill = await _context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);

            if (skill != null)
            {
                _context.Remove(skill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            var skills = await _context.Skills.ToListAsync();
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
            var skill = await _context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);
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
            var skill = await _context.Skills.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == skillDTO.Id);

            if (skill != null)
            {
                skill.Name = skillDTO.Name;
                skill.Description = skillDTO.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}

namespace LearnPortalASP.BLL.DataServices
{
    using LearnPortalASP.Models.CourseType;
    using Microsoft.EntityFrameworkCore;
    using LearnPortalASP.BLL.DTO;
    using LearnPortalASP.BLL.Interfaces;
    using LearnPortalASP.Data;
    using LearnPortalASP.Models.ViewModels;
    using LearnPortalASP.Models.MaterialType;

    public class CourseService : ICourseService
    {
        private readonly ApplicationContext _context;
        
        public CourseService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(CourseViewModel courseVM)
        {
            var skillsList = new List<Skill>();

            if (courseVM.SelectedSkills.Count != 0)
            {
                foreach (var skill in courseVM.SelectedSkills)
                {
                    skillsList.Add(await _context.Skills.FirstOrDefaultAsync(x => x.Id == skill));
                }
            }

            var materialsList = new List<Material>();

            if (courseVM.SelectedMaterials.Count != 0)
            {
                foreach (var material in courseVM.SelectedMaterials)
                {
                    materialsList.Add(await _context.Materials.FirstOrDefaultAsync(x => x.Id == material));
                }
            }

            await this._context.Courses.AddAsync(new Course
            {
                Name = courseVM.Name,
                Description = courseVM.Description,
                CreatorUserName = courseVM.CreatorUserName,
                CourseSkills = skillsList,
                CourseMaterials = materialsList
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<CourseDTO?> GetAsync(int? id)
        {
            var courseDto = await this._context.Courses
                .Select(x => new CourseDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CourseMaterials = x.CourseMaterials,
                    CreatorUserName = x.CreatorUserName,
                    CourseSkills = x.CourseSkills,
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return courseDto;
        }

        public async Task UpdateAsync(CourseDTO courseDTO)
        {
            var course = await this._context.Courses
                .FirstOrDefaultAsync(x => x.Id == courseDTO.Id);

            if (course != null)
            {
                course.Name = courseDTO.Name;
                course.Description = courseDTO.Description;
                course.CourseSkills = courseDTO.CourseSkills;
                course.CourseMaterials = courseDTO.CourseMaterials;
                course.CreatorUserName = course.CreatorUserName;

                this._context.Courses.Update(course);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await this._context.Courses.ToListAsync();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var item in courses)
            {
                CourseDTO courseDTO = new CourseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CourseMaterials = item.CourseMaterials,
                    CreatorUserName = item.CreatorUserName,
                    CourseSkills = item.CourseSkills
                };

                courseDTOs.Add(courseDTO);
            }

            return courseDTOs;
        }

        internal async Task AddSkill(int courseId, int skillId)
        {
            var course = await this._context.Courses.Include(x => x.CourseSkills).FirstOrDefaultAsync(x => x.Id == courseId);
            var skill = await this._context.Skills.FirstOrDefaultAsync(x => x.Id == skillId);

            if (course != null)
            {
                List<Skill> skills;
                if (course.CourseSkills == null)
                {
                    skills = new List<Skill>();
                }
                else
                {
                    skills = course.CourseSkills;
                }

                skills.Add(skill);
                course.CourseSkills = skills;
                this._context.Courses.Update(course);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int? id)
        {
            var course = await this._context.Courses.Include(x => x.CourseSkills).Include(x => x.CourseMaterials).FirstOrDefaultAsync(x => x.Id == id);

            if (course != null)
            {
                this._context.Remove(course);
                await this._context.SaveChangesAsync();
            }
        }
    }
}
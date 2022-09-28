namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.CourseType;
    using Microsoft.EntityFrameworkCore;
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.BLL.Interfaces;

    public class CourseService : ICourseService
    {
        private readonly ApplicationContext _context;
        
        public CourseService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CourseDTO courseDTO)
        {            
            await _context.Courses.AddAsync(new Course
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                CourseMaterials = courseDTO.CourseMaterials,
                CreatorId = courseDTO.CreatorId,
                CourseSkills = courseDTO.CourseSkills
            });

            await _context.SaveChangesAsync();
        }

        public async Task<CourseDTO?> GetAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            CourseDTO courseDTO = null;

            if (course != null)
            {
                courseDTO = new CourseDTO
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    CourseMaterials = course.CourseMaterials,
                    CreatorId = courseDTO.CreatorId,
                    CourseSkills = course.CourseSkills
                };

                return courseDTO;
            }
            else
            {
                return courseDTO;
            }
        }

        public async Task UpdateAsync(CourseDTO courseDTO)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseDTO.Id);

            if (course != null)
            {
                course.Name = courseDTO.Name;
                course.Description = courseDTO.Description;
                course.CourseSkills = courseDTO.CourseSkills;
                course.CourseMaterials = courseDTO.CourseMaterials;
                course.CreatorId = course.CreatorId;

                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var item in courses)
            {
                CourseDTO courseDTO = new CourseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CourseMaterials = item.CourseMaterials,
                    CourseSkills = item.CourseSkills
                };

                courseDTOs.Add(courseDTO);
            }

            return courseDTOs;
        }

        internal async Task AddSkill(int courseId, int skillId)
        {
            var course = await _context.Courses.Include(x => x.CourseSkills).FirstOrDefaultAsync(x => x.Id == courseId);
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == skillId);

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
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
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
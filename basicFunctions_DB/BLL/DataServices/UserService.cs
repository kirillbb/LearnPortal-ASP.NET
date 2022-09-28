namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.BLL.UI;
    using basicFunctions_DB.DAL;
    using Microsoft.EntityFrameworkCore;

    internal class UserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task ChangePassword(string oldPassword, string newPassword)
        {
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);
            
            if (oldPassword == user.Password)
            {
                user.Password = newPassword;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ChangeEmail(string oldEmail, string newEmail)
        {
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);

            if (oldEmail == user.Email)
            {
                user.Email = newEmail;
                this._context.Update(user);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<UserDTO> GetProfileAsync()
        {
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserSkillList = user.UserSkillList,
                Courses = user.Courses
            };

            return userDTO;
        }

        public async Task FinishCourse(int courseId)
        {
            var course = await _context.Courses.Include(x => x.CourseSkills).Include(x => x.CourseMaterials).FirstOrDefaultAsync(x => x.Id == courseId);
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);
            if (course != null)
            {
                if (await IsStudentAsync(course.Id))
                {
                    user.Courses.Remove(course);
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task TakeCourse(int courseId)
        {
            var course = await _context.Courses.Include(x => x.CourseSkills).Include(x => x.CourseMaterials).FirstOrDefaultAsync(x => x.Id == courseId);
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);
            if (course != null)
            {
                user.Courses.Add(course);
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsStudentAsync(int courseId)
        {
            var user = await _context.Users.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == UiService.AuthorizatedUser.Id);
            var course = await _context.Courses.Include(x => x.CourseSkills).Include(x => x.CourseMaterials).FirstOrDefaultAsync(x => x.Id == courseId);

            return user.Courses.Contains(course);
        }
    }
}

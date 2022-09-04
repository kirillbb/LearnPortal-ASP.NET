using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class CourseOperationService
    {
        private readonly ApplicationContext _context;
        public CourseOperationService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task StarterAsync()
        {
            Console.WriteLine();
            Printer.CoursesOperationsMenu();
            int menuItem = UiService.Controller();
            CourseService courseService = new CourseService(_context);
            UserService userService = new UserService(_context);

            switch (menuItem)
            {
                case 1:
                    await CreateCourseAsync();
                    Console.WriteLine();
                    break;
                case 2:
                    var course = await courseService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(course.ToString());
                    break;
                case 3:
                    await UpdateCourseAsync();
                    break;
                case 4:
                    await courseService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allCourses = await courseService.GetAllAsync();
                        foreach (var courseDTO in allCourses)
                        {
                            Console.WriteLine(courseDTO.ToString());
                        }

                        break;
                    }
                case 6:
                    await AddSkillsAsync();
                    break;
                case 7:
                    await userService.TakeCourse(UserInputService.GetId());
                    break;
                case 8:
                    await userService.FinishCourse(UserInputService.GetId());
                    break;
                case 9:
                    UiService uiService = new UiService(_context);
                    await uiService.GeneralMenuAsync();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    await StarterAsync();
                    break;
            }

            await StarterAsync();
        }

        private async Task AddSkillsAsync()
        {
            CourseService courseService = new CourseService(_context);
            SkillService skillService = new SkillService(_context);
            Console.WriteLine("Course");
            int courseId = UserInputService.GetId();
            Console.WriteLine("Skill");
            int skillId = UserInputService.GetId();
            await courseService.AddSkill(courseId, skillId);
        }

        private async Task UpdateCourseAsync()
        {
            CourseService courseService = new CourseService(_context);
            var course = UserInputService.AddCourse(UiService.AuthorizatedUser);
            course.Id = UserInputService.GetId();
            course.CreatorId = UiService.AuthorizatedUser.Id;
            await courseService.UpdateAsync(course);
        } 

        private async Task CreateCourseAsync()
        {
            CourseService courseService = new CourseService(_context);
            var course = UserInputService.AddCourse(UiService.AuthorizatedUser);
            course.CreatorId = UiService.AuthorizatedUser.Id;
            await courseService.CreateAsync(course);
        }
    }
}

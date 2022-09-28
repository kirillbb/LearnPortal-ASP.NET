namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.UI;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.PresentationLayer;

    internal class CourseOperationService
    {
        private readonly ApplicationContext _context;
        private readonly CourseService _courseService;
        private readonly UserService _userService;

        public CourseOperationService(ApplicationContext context)
        {
            _context = context;
            _courseService = new CourseService(_context);
            _userService = new UserService(_context);
        }

        public async Task StarterAsync()
        {
            Console.WriteLine();
            Printer.CoursesOperationsMenu();
            int menuItem = UiService.Controller();

            switch (menuItem)
            {
                case 1:
                    await CreateCourseAsync();
                    Console.WriteLine();
                    break;
                case 2:
                    var course = await _courseService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(course.ToString());
                    break;
                case 3:
                    await UpdateCourseAsync();
                    break;
                case 4:
                    await _courseService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allCourses = await _courseService.GetAllAsync();
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
                    await _userService.TakeCourse(UserInputService.GetId());
                    break;
                case 8:
                    await _userService.FinishCourse(UserInputService.GetId());
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
            SkillService skillService = new SkillService(_context);
            Console.WriteLine("Course");
            int courseId = UserInputService.GetId();
            Console.WriteLine("Skill");
            int skillId = UserInputService.GetId();
            await _courseService.AddSkill(courseId, skillId);
        }

        private async Task UpdateCourseAsync()
        {
            var course = UserInputService.AddCourse(UiService.AuthorizatedUser);
            course.Id = UserInputService.GetId();
            course.CreatorId = UiService.AuthorizatedUser.Id;
            await _courseService.UpdateAsync(course);
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

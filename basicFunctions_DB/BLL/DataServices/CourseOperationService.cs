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
            PrintMenu.CoursesOperations();
            int menuItem = UiService.Controller();
            CourseService courseService = new CourseService(_context);
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
        private async Task UpdateCourseAsync()
        {
            CourseService courseService = new CourseService(_context);
            var course = UserInputService.AddCourse(UiService.AuthorizatedUser);
            course.Id = UserInputService.GetId();
            await courseService.UpdateAsync(course);
        } 

        private async Task CreateCourseAsync()
        {
            CourseService courseService = new CourseService(_context);
            var course = UserInputService.AddCourse(UiService.AuthorizatedUser);
            await courseService.CreateAsync(course);
        }
    }
}

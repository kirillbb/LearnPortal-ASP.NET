using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class SkillOperationService
    {
        private readonly ApplicationContext _context;
        public SkillOperationService(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task StarterAsync()
        {
            Console.WriteLine();
            PrintMenu.SkillOperations();
            int menuItem = UiService.Controller();
            MaterialService materialService = new MaterialService(_context);

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
                        foreach (var material in allCourses)
                        {
                            Console.WriteLine(material.ToString());
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
    }
}

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
            Printer.SkillOperationsMenu();
            int menuItem = UiService.Controller();
            SkillService skillService = new SkillService(_context);

            switch (menuItem)
            {
                case 1:
                    await CreateSkillAsync();
                    Console.WriteLine();
                    break;
                case 2:
                    var course = await skillService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(course.ToString());
                    break;
                case 3:
                    await UpdateSkillAsync();
                    break;
                case 4:
                    await skillService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allSkills = await skillService.GetAllAsync();
                        foreach (var skill in allSkills)
                        {
                            Console.WriteLine(skill.ToString());
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

        private async Task UpdateSkillAsync()
        {
            SkillService skillService = new SkillService(_context);
            var skillDTO = UserInputService.AddSkill();
            skillDTO.Id = UserInputService.GetId();
            await skillService.UpdateAsync(skillDTO);
        }

        private async Task CreateSkillAsync()
        {
            SkillService skillService = new SkillService(_context);
            var skillDTO = UserInputService.AddSkill();
            await skillService.CreateAsync(skillDTO);
        }
    }
}

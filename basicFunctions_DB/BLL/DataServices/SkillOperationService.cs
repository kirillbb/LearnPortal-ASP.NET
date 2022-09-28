namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.UI;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.PresentationLayer;

    internal class SkillOperationService
    {
        private readonly ApplicationContext _context;
        private readonly SkillService _skillService;

        public SkillOperationService(ApplicationContext context)
        {
            _context = context;
            _skillService = new SkillService(context);
        }

        public async Task StarterAsync()
        {
            Console.WriteLine();
            Printer.SkillOperationsMenu();
            int menuItem = UiService.Controller();

            switch (menuItem)
            {
                case 1:
                    await CreateSkillAsync();
                    Console.WriteLine();
                    break;
                case 2:
                    var course = await _skillService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(course.ToString());
                    break;
                case 3:
                    await UpdateSkillAsync();
                    break;
                case 4:
                    await _skillService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allSkills = await _skillService.GetAllAsync();
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
            var skillDTO = UserInputService.AddSkill();
            skillDTO.Id = UserInputService.GetId();
            await _skillService.UpdateAsync(skillDTO);
        }

        private async Task CreateSkillAsync()
        {
            var skillDTO = UserInputService.AddSkill();
            await _skillService.CreateAsync(skillDTO);
        }
    }
}

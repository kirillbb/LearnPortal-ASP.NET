using basicFunctions_DB.BLL.Authorization;
using basicFunctions_DB.BLL.DataServices;
using basicFunctions_DB.DAL;
using basicFunctions_DB.DAL.UserType;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.UI
{
    internal class UiService
    {
        private readonly ApplicationContext _context;
        private readonly MaterialOperationService _materialOperationService;
        private readonly CourseOperationService _courseOperationService;
        private readonly SkillOperationService _skillOperationService;
        private readonly UserOperationService _userOperationService;


        public static User AuthorizatedUser { get; private set; }

        public UiService(ApplicationContext context)
        {
            this._context = context;
            this._materialOperationService = new MaterialOperationService(context);
            this._courseOperationService = new CourseOperationService(context);
            this._skillOperationService = new SkillOperationService(context);
            this._userOperationService = new UserOperationService(context);
        }

        public async Task Start()
        {
            do
            {
                await AuthorizationMenuAsync();
            } while (AuthorizatedUser == null);
            
            await GeneralMenuAsync();
        }

        public async Task GeneralMenuAsync()
        {
            Printer.GeneralMenu();
            int menuItem = Controller();
            switch (menuItem)
            {
                case 1:
                    await _materialOperationService.StarterAsync();
                    break;
                case 2:
                    await _courseOperationService.StarterAsync();
                    break;
                case 3:
                    await _skillOperationService.StarterAsync();
                    break;
                case 4:
                    await _userOperationService.StarterAsync();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    await GeneralMenuAsync();
                    break;
            }

            await GeneralMenuAsync();
        }

        private async Task AuthorizationMenuAsync()
        {
            Printer.AuthorizationMenu();
            int menuItem = Controller();
            switch (menuItem)
            {
                case 1:
                    {
                        var newUserDTO = UserInputService.Registration();
                        Registrator registrator = new Registrator(_context);
                        registrator.SignUp(email: newUserDTO.Email, password: newUserDTO.Password, name: newUserDTO.Name);
                        break;
                    }
                case 2:
                    {
                        var userDTO = UserInputService.Authorization();
                        Authorizator authorizator = new Authorizator(_context);
                        await authorizator.LogInAsync(email: userDTO.Email, password: userDTO.Password);
                        AuthorizatedUser = authorizator.AuthorizatedUser;
                        break;
                    }
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    await AuthorizationMenuAsync();
                    break;
            }
        }

        public static int Controller()
        {
            int menuItem;
            while (!int.TryParse(Console.ReadLine(), out menuItem))
            {
            }

            Printer.BreakLine();
            Printer.BreakLine();
            return menuItem;
        }
    }
}

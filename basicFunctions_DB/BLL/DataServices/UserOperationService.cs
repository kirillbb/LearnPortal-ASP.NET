using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class UserOperationService
    {
        private readonly ApplicationContext _context;
        private readonly UserService _userService;

        public UserOperationService(ApplicationContext context)
        {
            this._context = context;
            this._userService = new UserService(context);
        }

        public async Task StarterAsync()
        {
            Printer.Profile(await _userService.GetProfileAsync());
            Printer.ProfileMenu();
            
            int menuItem = UiService.Controller();
            
            switch (menuItem)
            {
                case 1:
                    Console.WriteLine("Old Email:");
                    string oldEmail = UserInputService.GetString();
                    Console.WriteLine("new Email:");
                    string newEmail = UserInputService.GetString();
                    await _userService.ChangeEmail(oldEmail, newEmail);
                    break;
                case 2:
                    Console.WriteLine("Old Password:");
                    string oldPassword = UserInputService.GetString();
                    Console.WriteLine("new Password:");
                    string newPassword = UserInputService.GetString();
                    await _userService.ChangePassword(oldPassword, newPassword);
                    break;
                case 3:
                    await _userService.TakeCourse(UserInputService.GetId());
                    break;
                case 4:
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
    }
}

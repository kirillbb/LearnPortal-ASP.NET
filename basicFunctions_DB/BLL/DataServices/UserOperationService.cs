using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class UserOperationService
    {
        private readonly ApplicationContext _context;
        public UserOperationService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task StarterAsync()
        {
            UserService userService = new UserService(_context);
            Printer.Profile(await userService.GetProfileAsync());
            Printer.ProfileMenu();
            
            int menuItem = UiService.Controller();
            
            switch (menuItem)
            {
                case 1:
                    Console.WriteLine("Old Email:");
                    string oldEmail = UserInputService.GetString();
                    Console.WriteLine("new Email:");
                    string newEmail = UserInputService.GetString();
                    await userService.ChangeEmail(oldEmail, newEmail);
                    break;
                case 2:
                    Console.WriteLine("Old Password:");
                    string oldPassword = UserInputService.GetString();
                    Console.WriteLine("new Password:");
                    string newPassword = UserInputService.GetString();
                    await userService.ChangePassword(oldPassword, newPassword);
                    break;
                case 3:
                    await userService.TakeCourse(UserInputService.GetId());
                    break;
                case 4:
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
    }
}

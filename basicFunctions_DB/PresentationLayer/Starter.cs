namespace basicFunctions_DB.PresentationLayer
{
    using basicFunctions_DB.BLL.UI;
    using basicFunctions_DB.DAL;
    using System.Threading.Tasks;

    internal class Starter
    {
        public async Task RunAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UiService uiService = new UiService(db);
                await uiService.Start();
            }
        }
    }
}

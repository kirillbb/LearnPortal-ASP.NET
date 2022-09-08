using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class MaterialOperationService
    {
        private readonly ApplicationContext _context;
        private readonly MaterialService _materialService;
        private readonly BookService _bookService;
        private readonly VideoService _videoService;
        private readonly PublicationService _publicationService;

        public MaterialOperationService(ApplicationContext context)
        {
            this._context = context;
            this._materialService = new MaterialService(context);
            this._bookService = new BookService(context);
            this._publicationService = new PublicationService(context);
            this._videoService = new VideoService(context);
        }

        public async Task StarterAsync()
        {
            Console.WriteLine();
            Printer.MaterialOperationsMenu();
            int menuItem = UiService.Controller();

            switch (menuItem)
            {
                case 1:
                    await CreateMaterialAsync(await ChooseMaterialTypeMenuAsync());
                    break;
                case 2:
                    await FindMaterialAsync(await ChooseMaterialTypeMenuAsync());
                    break;
                case 3:
                    await UpdateMaterialAsync(await ChooseMaterialTypeMenuAsync());
                    break;
                case 4:
                    _materialService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allMaterials = await _materialService.GetAllAsync();
                        foreach (var material in allMaterials)
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
        public async Task UpdateMaterialAsync(string materialType)
        {
            switch (materialType)
            {
                case "book":
                    var book = UserInputService.AddBook(UiService.AuthorizatedUser);
                    book.Id = UserInputService.GetId();
                    await _bookService.UpdateAsync(book);
                    break;
                case "video":
                    var video = UserInputService.AddVideo(UiService.AuthorizatedUser);
                    video.Id = UserInputService.GetId();
                    await _videoService.UpdateAsync(video);
                    break;
                case "publication":
                    var publication = UserInputService.AddPublication(UiService.AuthorizatedUser);
                    publication.Id = UserInputService.GetId();
                    await _publicationService.UpdateAsync(publication);
                    break;
                default:
                    break;
            }
        }
        private async Task FindMaterialAsync(string materialType)
        {
            switch (materialType)
            {
                case "book":
                    var book = await _bookService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(book.ToString());
                    break;
                case "video":
                    var video = await _videoService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(video.ToString());
                    break;
                case "publication":
                    var publication = await _publicationService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(publication.ToString());
                    break;
                default:
                    break;
            }
        }

        private async Task<string?> ChooseMaterialTypeMenuAsync()
        {
            Printer.ChooseMaterialTypeMenu();
            int menuItem = UiService.Controller();
            string type = null;
            switch (menuItem)
            {
                case 1:
                    type = "book";
                    break;
                case 2:
                    type = "video";
                    break;
                case 3:
                    type = "publication";
                    break;
                case 9:
                    await StarterAsync();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    ChooseMaterialTypeMenuAsync();
                    break;
            }

            if (type == null)
            {
                ChooseMaterialTypeMenuAsync();
            }

            return type;
        }

        public async Task CreateMaterialAsync(string materialType)
        {
            switch (materialType)
            {
                case "book":
                    var book = UserInputService.AddBook(UiService.AuthorizatedUser);
                    await _bookService.CreateAsync(book);
                    break;
                case "video":
                    var video = UserInputService.AddVideo(UiService.AuthorizatedUser);
                    await _videoService.CreateAsync(video);
                    break;
                case "publication":
                    var publication = UserInputService.AddPublication(UiService.AuthorizatedUser);
                    await _publicationService.CreateAsync(publication);
                    break;
                default:
                    break;
            }
        }
    }
}

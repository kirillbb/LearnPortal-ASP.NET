using basicFunctions_DB.BLL.UI;
using basicFunctions_DB.DAL;
using basicFunctions_DB.PresentationLayer;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class MaterialOperationService
    {
        private readonly ApplicationContext _context;
        public MaterialOperationService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task StarterAsync()
        {
            Console.WriteLine();
            PrintMenu.MaterialOperations();
            int menuItem = UiService.Controller();
            MaterialService materialService = new MaterialService(_context);

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
                    materialService.DeleteAsync(UserInputService.GetId());
                    break;
                case 5:
                    {
                        var allMaterials = await materialService.GetAllAsync();
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
                    BookService bookService = new BookService(_context);
                    var book = UserInputService.AddBook(UiService.AuthorizatedUser);
                    book.Id = UserInputService.GetId();
                    await bookService.UpdateAsync(book);
                    break;
                case "video":
                    VideoService videoService = new VideoService(_context);
                    var video = UserInputService.AddVideo(UiService.AuthorizatedUser);
                    video.Id = UserInputService.GetId();
                    await videoService.UpdateAsync(video);
                    break;
                case "publication":
                    PublicationService publicationService = new PublicationService(_context);
                    var publication = UserInputService.AddPublication(UiService.AuthorizatedUser);
                    publication.Id = UserInputService.GetId();
                    await publicationService.UpdateAsync(publication);
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
                    BookService bookService = new BookService(_context);
                    var book = await bookService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(book.ToString());
                    break;
                case "video":
                    VideoService videoService = new VideoService(_context);
                    var video = await videoService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(video.ToString());
                    break;
                case "publication":
                    PublicationService publicationService = new PublicationService(_context);
                    var publication = await publicationService.GetAsync(UserInputService.GetId());
                    Console.WriteLine(publication.ToString());
                    break;
                default:
                    break;
            }
        }

        private async Task<string?> ChooseMaterialTypeMenuAsync()
        {
            PrintMenu.ChooseMaterialType();
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
                    BookService bookService = new BookService(_context);
                    var book = UserInputService.AddBook(UiService.AuthorizatedUser);
                    await bookService.CreateAsync(book);
                    break;
                case "video":
                    VideoService videoService = new VideoService(_context);
                    var video = UserInputService.AddVideo(UiService.AuthorizatedUser);
                    await videoService.CreateAsync(video);
                    break;
                case "publication":
                    PublicationService publicationService = new PublicationService(_context);
                    var publication = UserInputService.AddPublication(UiService.AuthorizatedUser);
                    await publicationService.CreateAsync(publication);
                    break;
                default:
                    break;
            }
        }
    }
}

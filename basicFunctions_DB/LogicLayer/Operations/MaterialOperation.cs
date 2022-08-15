namespace basicFunctions_DB.LogicLayer.Operations
{
    using basicFunctions_DB.DataLayer;
    using basicFunctions_DB.DataLayer.MaterialType;
    using basicFunctions_DB.FacadeLayer;
    using basicFunctions_DB.GenericRepository;
    using basicFunctions_DB.LogicLayer.Authorization;

    internal static class MaterialOperation
    {
        public static void Run()
        {
            Control();
        }

        private static void Control()
        {
            PrintMenu.MaterialOperations();
            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            switch (menuItem)
            {
                case 1:
                    CreateMaterial();
                    break;
                case 2:
                    FindById();
                    break;
                case 3:
                    UpdateMaterial();
                    break;
                case 4:
                    DeleteMaterial();
                    break;
                case 5:
                    PrintAll();
                    break;
                case 9:
                    OperationControler.Control();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
            Control();
        }

        private static void PrintAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                Console.WriteLine("List of all materials:");
                var list = repository.GetAll();
                foreach (var material in list)
                {
                    Console.WriteLine(material.Id + " " + material.Title + " " + material.ToString());
                }

                Console.ReadLine();
                Control();
            }
        }

        private static void DeleteMaterial()
        {
            int id = 0;
            Console.WriteLine("Enter material-ID to remove:");
            int.TryParse(Console.ReadLine(), out id);

            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);
                repository.Delete(id);
                repository.Save();
            }
            Console.WriteLine();
            Console.ReadLine();
            Control();
        }

        private static void UpdateMaterial()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                Console.WriteLine("Enter ID:");
                string id = Console.ReadLine();
                var material = repository.GetById(int.Parse(id));

                Console.WriteLine($"Current TiTle = {material.Title} enter a new Title:");
                material.Title = Console.ReadLine();

                //if (material.GetType().Name == "Book")
                //{
                //    material = new Book();
                //    // ???
                //    Console.WriteLine($"Current Author = {} enter a new Author:");
                //    string author = Console.ReadLine();
                //    Console.WriteLine($"Current Format = {} enter a new Format:");
                //    string format = Console.ReadLine();
                //    Console.WriteLine($"Current pages count = {} enter a new pages count:");
                //    string pages = Console.ReadLine();
                //    Console.WriteLine($"Current Publication date = {} enter a new Publication date:");
                //    string date = Console.ReadLine();
                //}
                //else if(material.GetType().Name == "Video")
                //{
                //    // ???
                //    Console.WriteLine($"Current Duration date = {} enter a new Duration :");
                //    string duration = Console.ReadLine();
                //    Console.WriteLine($"Current Resolution date = {} enter a new Resolution:");
                //    string resolution = Console.ReadLine();
                //}
                //else
                //{
                //    // ???
                //    Console.WriteLine($"Current Publication date date = {} enter a new Publication date:");
                //    string date = Console.ReadLine();

                //    Console.WriteLine($"Current Link date = {} enter a new Link :");
                //    string source = Console.ReadLine();
                //}

                repository.Update(material);

                repository.Save();
            }

            Console.ReadLine();
            Control();
        }

        private static void FindById()
        {
            Console.WriteLine("Enter ID:");
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                string id = Console.ReadLine();
                var material = repository.GetById(int.Parse(id));

                Console.WriteLine("ID: " + material.Id + " \"" + material.Title + "\" " + material.ToString());

                Console.ReadLine();
            }
        }

        private static void CreatePublication()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                Publication publication;
                Console.WriteLine("Title:");
                string title = Console.ReadLine();

                Console.WriteLine("Publication date");
                string date = Console.ReadLine();

                Console.WriteLine("Link:");
                string source = Console.ReadLine();

                publication = new Publication
                {
                    Creator = db.Users.Where(x => x.Id == AuthorizationControler.AuthorizatedUser.Id).FirstOrDefault(),
                    Source = source,
                    Title = title,
                    CreationDate = DateTime.Parse(date)
                };


                repository.Insert(publication);
                repository.Save();
            }
        }

        private static void CreateVideo()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                Video video;
                Console.WriteLine("Title:");
                string title = Console.ReadLine();
                Console.WriteLine("Duration:");
                string duration = Console.ReadLine();
                Console.WriteLine("Resolution:");
                string resolution = Console.ReadLine();

                video = new Video
                {
                    Creator = db.Users.Where(x => x.Id == AuthorizationControler.AuthorizatedUser.Id).FirstOrDefault(),
                    Duration = int.Parse(duration),
                    Resolution = int.Parse(resolution),
                    Title = title
                };

                repository.Insert(video);
                repository.Save();
            }
        }

        private static void CreateBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);

                Book book;
                Console.WriteLine("Author:");
                string author = Console.ReadLine();
                Console.WriteLine("Title:");
                string title = Console.ReadLine();
                Console.WriteLine("Format:");
                string format = Console.ReadLine();
                Console.WriteLine("Pages:");
                string pages = Console.ReadLine();
                Console.WriteLine("Publication date:");
                string date = Console.ReadLine();

                book = new Book
                {
                    Author = author,
                    BookFormat = format,
                    Creator = db.Users.Where(x => x.Id == AuthorizationControler.AuthorizatedUser.Id).FirstOrDefault(),
                    Pages = int.Parse(pages),
                    Title = title,
                    PublicationDate = DateTime.Parse(date)
                };

                repository.Insert(book);
                repository.Save();
            }
        }

        private static void CreateMaterial()
        {
            PrintMenu.ChooseMaterialType();

            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            switch (menuItem)
            {
                case 1:
                    CreateBook();
                    break;
                case 2:
                    CreateVideo();
                    break;
                case 3:
                    CreatePublication();
                    break;
                case 9:
                    MaterialOperation.Control();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            CreateMaterial();
        }
    }
}

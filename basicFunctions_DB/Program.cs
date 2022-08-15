namespace basicFunctions_DB
{
    using basicFunctions_DB.DataLayer;
    using basicFunctions_DB.DataLayer.CourseType;
    using basicFunctions_DB.DataLayer.MaterialType;
    using basicFunctions_DB.DataLayer.UserType;
    using basicFunctions_DB.FacadeLayer;
    using basicFunctions_DB.GenericRepository;
    using basicFunctions_DB.LogicLayer.Authorization;
    using System.Linq;

    public static class Program
    {
        static void Main(string[] args)
        {
            // DbTest();

            Starter starter = new Starter();
            starter.Run();

            // RepositoryTest();
        }

        private static void RepositoryTest()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Material> repository = new GenericRepository<Material>(db);
                var material = repository.GetById(3);
                var material2 = repository.GetById(4);
                var material3 = repository.GetById(5);
                var material4 = repository.GetWithInclude(x => x.Creator);

                var material5 = material4.ToList();
                foreach (var item in material5)
                {
                    var mater = item;
                }
                var list = repository.GetAll();

                User user = AuthorizationControler.AuthorizatedUser;
                Book book = new Book { Author = "J.Aive", BookFormat = "docx", Creator = db.Users.Where(x => x.Id == user.Id).FirstOrDefault(), Pages = 202, Title = "Apple is not just design", PublicationDate = DateTime.Parse("12.05.2022") };

                repository.Insert(book);
                repository.Save();

                Console.WriteLine();
            }
        }

        static void DbTest()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User { Email = "stepan@gmail.com", Name = "Stepan", Password = "Stepan" };

                Course course = new Course { Creator = user, Description = "Start in front design-development", Name = "Front-end" };
                Course course2 = new Course { Creator = user, Description = "Dolores", Name = "Back-End" };

                List<Course> courses = new List<Course>();
                courses.Add(course);
                courses.Add(course2);

                Book book = new Book { Author = "S.Fires", BookFormat = "docx", Creator = user, Pages = 101, Title = "How to be a developer", PublicationDate = DateTime.Parse("12.05.2012") };
                Video video = new Video { Title = "Settings in Sublime", Creator = user, Duration = 12, Resolution = 1080 };
                Publication publication = new Publication { Title = "Basics HTML", CreationDate = DateTime.Parse("25.08.2019"), Creator = user, Source = "htmlacademy.ru" };
                Book bookPhp = new Book { Author = "P.Hackswell", BookFormat = "epub", Creator = user, Pages = 800, Title = "How to PhP", PublicationDate = DateTime.Parse("12.05.2016") };

                List<Material> materials = new List<Material>();
                materials.Add(book);
                materials.Add(video);
                materials.Add(publication);
                List<Material> materials2 = new List<Material>();
                materials2.Add(book);
                materials2.Add(publication);
                materials2.Add(bookPhp);

                course.CourseMaterials = materials;
                course2.CourseMaterials = materials2;

                Skill skill1 = new Skill { Name = "Html", Description = "basics" };
                Skill skill2 = new Skill { Name = "Node.js", Description = "basics" };
                Skill skill3 = new Skill { Name = "Php", Description = "basics" };
                Skill skill4 = new Skill { Name = "SQL", Description = "dataBase base" };

                List<Skill> skills = new List<Skill>();
                skills.Add(skill1);
                skills.Add(skill2);
                List<Skill> skills2 = new List<Skill>();
                skills2.Add(skill3);
                skills2.Add(skill4);

                course.CourseSkills = skills;
                course2.CourseSkills = skills2;

                db.Materials.AddRange(book, video, publication, bookPhp);
                db.Skills.AddRange(skill1, skill2);
                db.Courses.AddRange(course, course2);
                db.Users.AddRange(user);

                db.SaveChanges();
            }
        }
    }
}
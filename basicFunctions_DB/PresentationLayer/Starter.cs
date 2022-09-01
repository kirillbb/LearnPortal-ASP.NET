namespace basicFunctions_DB.PresentationLayer
{
    using basicFunctions_DB.BLL.Authorization;
    using basicFunctions_DB.BLL.DataServices;
    using basicFunctions_DB.BLL.DTO;
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
                //PublicationService publicationService = new PublicationService(db);

                //var list = await publicationService.GetAllAsync();
                //foreach (var item in list)
                //{
                //    Console.WriteLine($"{item.Id}_{item.Title}-{item.Creator}-{item.CreationDate}-{item.Source}");
                //}
            }
        }

        //public async Task TestCourseServices()
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        CourseService courseService = new CourseService(db);

        //        var list = await courseService.GetAllAsync();
        //        foreach (var item in list)
        //        {
        //            Console.WriteLine($"Id:{item.Id} Name:\"{item.Name}\" Description:{item.Description} Creator:{item.Creator}");
        //        }
        //        Console.ReadLine();

        //        CourseDTO course = await courseService.GetAsync(4);
        //        Console.WriteLine($"Id:{course.Id} Name:\"{course.Name}\" Description:{course.Description} Creator:{course.Creator}");

        //        CourseDTO courseDTO = new CourseDTO
        //        {
        //            Id = 4,
        //            Name = "New name",
        //            Creator = course.Creator,
        //            Description = course.Description
        //        };
        //        await courseService.UpdateAsync(courseDTO);
        //        CourseDTO newCourse = await courseService.GetAsync(4);
        //        Console.WriteLine($"Id:{newCourse.Id} Name:\"{newCourse.Name}\" Description:{newCourse.Description} Creator:{newCourse.Creator}");

        //        CourseDTO courseDTO1 = new CourseDTO
        //        {
        //            Name = "Created Course",
        //            Description = "o wow, created description",
        //            Creator = newCourse.Creator //await this._context.Users.FirstOrDefaultAsync(x => x.Id == AuthorizationControler.AuthorizatedUser.Id)
        //        };

        //        await courseService.CreateAsync(courseDTO1);

        //        var list1 = await courseService.GetAllAsync();
        //        foreach (var item in list1)
        //        {
        //            Console.WriteLine($"Id:{item.Id} Name:\"{item.Name}\" Description:{item.Description} Creator:{item.Creator}");
        //        }
        //        Console.ReadLine();

        //        await courseService.DeleteAsync(6);
        //        var list2 = await courseService.GetAllAsync();
        //        foreach (var item in list2)
        //        {
        //            Console.WriteLine($"Id:{item.Id} Name:\"{item.Name}\" Description:{item.Description} Creator:{item.Creator}");
        //        }

        //    }
        //}

        //private void ChooseGeneralMenuItem()
        //{
        //    try
        //    {
        //        OperationControler.Control();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private void TryAuthorizate()
        //{
        //    PrintMenu.Authorization();

        //    try
        //    {
        //        //AuthorizationService.Control();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}

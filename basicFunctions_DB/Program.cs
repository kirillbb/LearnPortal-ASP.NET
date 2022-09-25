namespace basicFunctions_DB
{
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.PresentationLayer;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Starter starter = new Starter();
            await starter.RunAsync();
            
        }
    }
}
using basicFunctions_DB.DAL.UserType;

namespace basicFunctions_DB.BLL.DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? CreatorUserName { get; set; }

        public string Discriminator { get; set; }
    }
}

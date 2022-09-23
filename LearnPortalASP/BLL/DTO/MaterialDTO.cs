using LearnPortalASP.Models.UserType;
using System.ComponentModel.DataAnnotations;

namespace LearnPortalASP.BLL.DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string? CreatorUserName { get; set; }

        public string Discriminator { get; set; }
    }
}

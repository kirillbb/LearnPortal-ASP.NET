using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnPortalASP.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvchar(100)")]
        public string LastName { get; set; }

    }
}

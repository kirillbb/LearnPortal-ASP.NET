using LearnPortalASP.Models.CourseType;
using LearnPortalASP.Models.MaterialType;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LearnPortalASP.Models.ViewModels
{
    public class CourseViewModel
    {
        public List<SelectListItem>? SkillSelectList { get; set; }

        public List<int> SelectedSkillId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Material>? CourseMaterials { get; set; }


        [Required(ErrorMessage = "You must be authorizated!")]
        public string CreatorUserName { get; set; }
    }
}

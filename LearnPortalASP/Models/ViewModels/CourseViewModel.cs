using LearnPortalASP.Models.CourseType;
using LearnPortalASP.Models.MaterialType;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LearnPortalASP.Models.ViewModels
{
    public class CourseViewModel
    {
        public List<SelectListItem>? SkillSelectList { get; set; }

        public List<int> SelectedSkills { get; set; }

        public List<SelectListItem>? MaterialSelectList { get; set; }

        public List<int> SelectedMaterials { get; set; }

        public List<string>? Materials { get; set; }

        public List<string>? Skills { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string CreatorUserName { get; set; }
    }
}

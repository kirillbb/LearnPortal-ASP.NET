using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    internal class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Material> Materials { get; set; }
        public List<Skill> CourseSkillList { get; set; }
    }
}

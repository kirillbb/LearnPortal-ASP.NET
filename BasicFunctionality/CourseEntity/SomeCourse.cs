// <copyright file="SomeCourse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class SomeCourse
    {
        public SomeCourse(int id, string? name, string? description, List<IMaterial>? materialList, List<Skill>? courseSkillList, User? creator)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.MaterialList = materialList;
            this.CourseSkillList = courseSkillList;
            this.Creator = creator;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<IMaterial>? MaterialList { get; set; }

        public List<Skill>? CourseSkillList { get; set; }

        public User? Creator { get; set; }
    }
}

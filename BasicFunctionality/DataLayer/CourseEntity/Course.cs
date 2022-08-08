// <copyright file="Course.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class Course
    {
        public Course(int id, string? name, string? description, List<IMaterial>? materialList, List<Skill>? courseSkillList, User? creator)
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

        public override string ToString()
        {
            return $"Name: {this.Name} Description: {this.Description}\n Materials: {this.MaterialList} Skills: {this.CourseSkillList} Creator: {this.Creator} ID: {this.Id}";
        }
    }
}

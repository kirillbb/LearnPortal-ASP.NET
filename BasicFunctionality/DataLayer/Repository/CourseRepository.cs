// <copyright file="CourseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal class CourseRepository<TCourse> : ICourseRepository, IEnumerable
    {
        private List<Course> data;
        private string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\courses.txt";

        public CourseRepository()
        {
            var jsons = File.ReadLines(this.path);
            List<Course> courses = new List<Course>();

            foreach (string json in jsons)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                courses.Add(JsonConvert.DeserializeObject<Course>(json.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }

            this.data = courses;
        }

        private List<Course> Data
        {
            get { return this.data; }
        }

        public Course? FindById(int id)
        {
            foreach (var item in this.data)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void Create(Course course)
        {
            this.data.Add(course);
            this.SaveChanges(course);
        }

        public void Update(Course course, string? newName, string? newDescription, List<IMaterial>? newMaterialList, List<Skill>? newCourseSkillList, User? newCreator)
        {
            foreach (var oldCourse in this.data)
            {
                if (oldCourse == course)
                {
                    oldCourse.Name = newName;
                    oldCourse.Description = newDescription;
                    oldCourse.Creator = newCreator;
                    oldCourse.CourseSkillList = newCourseSkillList;
                    oldCourse.MaterialList = newMaterialList;
                }
            }

            this.SaveChanges(this.data);
        }

        public void Remove(Course course)
        {
            this.data.Remove(course);
            this.SaveChanges(this.data);
        }

        public void SaveChanges(List<Course> courses)
        {
            File.WriteAllText(this.path, string.Empty);
            foreach (var item in courses)
            {
                string json = JsonConvert.SerializeObject(item);

                using (System.IO.StreamWriter writer = new (this.path, true))
                {
                    writer.WriteLine(json);
                }
            }

            Console.WriteLine("Material saved");
        }

        public void SaveChanges(Course course)
        {
            string json = JsonConvert.SerializeObject(course);

            using (System.IO.StreamWriter writer = new (this.path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("Material saved");
        }

        public IEnumerator GetEnumerator() => this.data.GetEnumerator();
    }
}

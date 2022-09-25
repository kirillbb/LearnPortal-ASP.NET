// <copyright file="ICourseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using System.Collections;

    public interface ICourseRepository
    {
        public Course? FindById(int id);

        public void Create(Course course);

        public void Update(Course course, string? newName, string? newDescription, List<IMaterial>? newMaterialList, List<Skill>? newCourseSkillList, User? newCreator);

        public void Remove(Course course);

        public IEnumerator GetEnumerator();
    }
}

// <copyright file="SkillRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using Newtonsoft.Json;

    internal class SkillRepository<TSkill>
    {
        private List<Skill> data;
        private string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\videos.txt";

        public SkillRepository()
        {
            var jsons = File.ReadLines(this.path);
            List<Skill> skills = new List<Skill>();

            foreach (string json in jsons)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                skills.Add(JsonConvert.DeserializeObject<Skill>(json.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }

            this.data = skills;
        }

        private List<Skill> Data
        {
            get { return this.data; }
        }

        public Skill? FindById(int id)
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

        public void Create(Skill skill)
        {
            this.data.Add(skill);
            this.SaveChanges(skill);
        }

        public void Update(Skill skill, string newName, string newDescription)
        {
            foreach (var oldSkill in this.data)
            {
                if (oldSkill == skill)
                {
                    oldSkill.Name = newName;
                    oldSkill.Description = newDescription;
                }
            }

            this.SaveChanges(this.data);
        }

        public void Remove(Skill skill)
        {
            this.data.Remove(skill);
            this.SaveChanges(this.data);
        }

        public void SaveChanges(List<Skill> skills)
        {
            File.WriteAllText(this.path, string.Empty);
            foreach (var item in skills)
            {
                string json = JsonConvert.SerializeObject(item);

                using (System.IO.StreamWriter writer = new (this.path, true))
                {
                    writer.WriteLine(json);
                }
            }

            Console.WriteLine("Material saved");
        }

        public void SaveChanges(Skill skils)
        {
            string json = JsonConvert.SerializeObject(skils);

            using (System.IO.StreamWriter writer = new (this.path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("Material saved");
        }
    }
}

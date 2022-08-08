// <copyright file="PublicationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using System.Collections;
    using Newtonsoft.Json;

    public class PublicationRepository<TPublication> : IEnumerable
    {
        private List<Publication> data;
        private string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\publications.txt";

        public PublicationRepository()
        {
            var jsons = File.ReadLines(this.path);
            List<Publication> materials = new List<Publication>();

            foreach (string json in jsons)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                materials.Add(JsonConvert.DeserializeObject<Publication>(json.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }

            this.data = materials;
        }

        private List<Publication> Data
        {
            get { return this.data; }
        }

        public Publication? FindById(int id)
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

        public void Create(Publication publication)
        {
            this.data.Add(publication);
            this.SaveChanges(publication);
        }

        public IEnumerator GetEnumerator() => this.data.GetEnumerator();

        public void Update(Publication publication, User newCreator, DateTime newCreationDate, string newSourse, string newTitle)
        {
            foreach (var oldPublication in this.data)
            {
                if (oldPublication == publication)
                {
                    oldPublication.CreationDate = newCreationDate;
                    oldPublication.Title = newTitle;
                    oldPublication.Source = newSourse;
                    oldPublication.Creator = newCreator;
                }
            }

            this.SaveChanges(this.data);
        }

        public void Remove(Publication publication)
        {
            this.data.Remove(publication);
            this.SaveChanges(this.data);
        }

        public void SaveChanges(List<Publication> publications)
        {
            File.WriteAllText(this.path, string.Empty);
            foreach (var item in publications)
            {
                string json = JsonConvert.SerializeObject(item);

                using (System.IO.StreamWriter writer = new (this.path, true))
                {
                    writer.WriteLine(json);
                }
            }

            Console.WriteLine("Material saved");
        }

        public void SaveChanges(Publication publication)
        {
            string json = JsonConvert.SerializeObject(publication);

            using (System.IO.StreamWriter writer = new (this.path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("Material saved");
        }
    }
}

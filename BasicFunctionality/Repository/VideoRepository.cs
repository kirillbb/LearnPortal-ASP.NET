// <copyright file="VideoRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using Newtonsoft.Json;

    public class VideoRepository<TVideo>
    {
        private List<Video> data;
        private string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\videos.txt";

        public VideoRepository()
        {
            var jsons = File.ReadLines(this.path);
            List<Video> materials = new List<Video>();

            foreach (string json in jsons)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                materials.Add(JsonConvert.DeserializeObject<Video>(json.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }

            this.data = materials;
        }

        private List<Video> Data
        {
            get { return this.data; }
        }

        public Video? FindById(int id)
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

        public void Create(Video video)
        {
            this.data.Add(video);
            this.SaveChanges(video);
        }

        public void Update(Video video, User newCreator, int newResolution, string newTitle, int newDuretionInMinutes)
        {
            foreach (var oldVideo in this.data)
            {
                if (oldVideo == video)
                {
                    oldVideo.Title = newTitle;
                    oldVideo.Duration = newDuretionInMinutes;
                    oldVideo.Resolution = newResolution;
                    oldVideo.Creator = newCreator;
                }
            }

            this.SaveChanges(this.data);
        }

        public void Remove(Video video)
        {
            this.data.Remove(video);
            this.SaveChanges(this.data);
        }

        public void SaveChanges(List<Video> videos)
        {
            File.WriteAllText(this.path, string.Empty);
            foreach (var item in videos)
            {
                string json = JsonConvert.SerializeObject(item);

                using (System.IO.StreamWriter writer = new (this.path, true))
                {
                    writer.WriteLine(json);
                }
            }

            Console.WriteLine("Material saved");
        }

        public void SaveChanges(Video videos)
        {
            string json = JsonConvert.SerializeObject(videos);

            using (System.IO.StreamWriter writer = new (this.path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("Material saved");
        }
    }
}

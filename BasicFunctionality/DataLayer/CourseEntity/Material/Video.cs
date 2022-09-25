// <copyright file="Video.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public partial class Video : IMaterial
    {
        public Video(User creator, int resolution, string title, int duretionInMinutes)
        {
            this.Creator = creator;
            this.Resolution = resolution;
            this.Title = title;
            this.Duration = duretionInMinutes;
            this.Id = SetId();
            this.Type = MaterialType.Video;
        }

        public int Resolution { get; set; }

        public int Duration { get; set; }

        public string? Title { get; set; }

        public int Id { get; set; }

        public User Creator { get; set; }

        public MaterialType Type { get; }

        public override string ToString()
        {
            return $"Title: {this.Title} Resolution: {this.Resolution} {this.Duration} minutes,\nCreator: {this.Creator} MaterialType: {this.Type.ToString()} ID: {this.Id}";
        }

        private static int SetId()
        {
            string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\videos.txt";
            int id = 1;

            if (File.Exists(path))
            {
                using (TextReader reader = new StreamReader(path))
                {
                    while (reader.ReadLine() != null)
                    {
                        id++;
                    }
                }
            }

            return id;
        }
    }
}

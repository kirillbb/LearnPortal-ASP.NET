namespace basicFunctions_DB.BLL.DTO
{
    internal class VideoDTO : MaterialDTO
    {
        public int Resolution { get; set; }

        public int Duration { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} | Title: \"{Title}\" | Resolution: {Resolution}p | Duration: {Duration} minutes | added: {Creator.ToString} ";
        }
    }
}

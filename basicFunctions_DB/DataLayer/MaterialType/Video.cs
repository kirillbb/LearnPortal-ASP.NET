namespace basicFunctions_DB.DataLayer.MaterialType
{
    public class Video : Material
    {
        public int Resolution { get; set; }

        public int Duration { get; set; }

        public override string ToString()
        {
            return $"{Duration} minutes - ({Resolution}p)";
        }
    }
}

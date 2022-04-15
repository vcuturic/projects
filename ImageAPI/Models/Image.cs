namespace virtouz_image_api.Models
{
    public class Image
    {
        public int id { get; set; }
        public string location { get; set; }

        public Image(int id, string location)
        {
            this.id = id;
            this.location = location;
        }
    }
}

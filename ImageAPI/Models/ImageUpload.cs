using Microsoft.AspNetCore.Http;

namespace virtouz_image_api.Models
{
    public class ImageUpload
    {
        public IFormFile images { get; set; } // used as key for post method: "images"
    }
}

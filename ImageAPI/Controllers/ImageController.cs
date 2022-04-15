using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using virtouz_image_api.Database;
using virtouz_image_api.Models;

namespace virtouz_image_api.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        ImageDb imgdb = new ImageDb();
        [HttpPost("upload")]
        public ActionResult Post([FromForm] ImageUpload objectFile)
        {
            int pictureId;
            try
            {
                if (objectFile.images.Length > 0)
                {
                    string path = Directory.GetCurrentDirectory() + @"/uploads/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    pictureId = imgdb.addPicture(path, objectFile.images.FileName);
                    if (pictureId != -1)
                    {
                        using (FileStream fileStream = System.IO.File.Create(path + pictureId + objectFile.images.FileName))
                        {
                            objectFile.images.CopyTo(fileStream);
                            fileStream.Flush();

                        }
                        return Ok(new { Message = "Picture successfully uploaded.", id = pictureId});
                    }
                    return BadRequest(new { Message = "Picture did not upload succsesfully." });
                }
                else
                {
                    return BadRequest(new { Message = "Picture did not upload succsesfully." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult <IEnumerable<Image>> getAllImages()
        {
            var images = imgdb.getAllImages();
            for (int i = 0; i < images.Count; i++)
            {
                images[i].location = "/api/pictures/" + images[i].id;
            }
            return Ok(images);
        }
        [HttpGet("{id}")]
        public ActionResult getImageById(int id)
        {
            string locimage = imgdb.getImageById(id);
            if (!System.IO.File.Exists(locimage))
            {
                return BadRequest(new { Message = "Image not found." });
            }
            Byte[] b = System.IO.File.ReadAllBytes(locimage);
            return File(b, "image/jpeg");
        }
    }
}

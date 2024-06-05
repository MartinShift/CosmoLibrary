using CosmoLibrary.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmoLibrary.Controllers;

[ApiController]
[Route("/images")]
public class ImageController : ControllerBase
{
    private readonly ImageService _imageService;

    public ImageController(ImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> UploadImage(IFormFile image)
    {
        var imageUrl = await _imageService.Upload(image);
        return Ok(imageUrl);
    }
    
}

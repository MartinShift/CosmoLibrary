using Azure.Storage.Blobs;

namespace CosmoLibrary.Business.Services;

public class ImageService
{
    private readonly IConfiguration _configuration;

    public ImageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<string> Upload(IFormFile? file)
    {
        if (file == null)
        {
            return string.Empty;
        }

        var connectionString = _configuration.GetValue<string>("Azure:BlobStorage:ConnectionString");

        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        string containerName = "images";
        BlobContainerClient containerClient;

        if (blobServiceClient.GetBlobContainers().Any(x => x.Name == containerName))
        {
            containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        }
        else
        {
            containerClient = blobServiceClient.CreateBlobContainer(containerName);
        }
        var blobFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var blobClient = containerClient.GetBlobClient(blobFileName);
        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream);
        }
        return blobClient.Uri.AbsoluteUri;
    }
}

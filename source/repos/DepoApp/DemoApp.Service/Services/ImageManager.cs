using DemoApp.Service.Interfaces;

namespace DemoApp.Service.Services
{
    public class ImageManager : IImageManager

    {
        private const string _baseURL = "C:\\Users\\User\\source\\repos\\DepoApp\\CarsProject\\Images";

        public async Task<string> ComposeAsync(string path)
        {
            byte[] image = await File.ReadAllBytesAsync(path);
            string filename = Guid.NewGuid().ToString();
            FileInfo fileInfo = new FileInfo(path);
            filename = filename + fileInfo.Extension;
            string newPath = _baseURL + filename;
            await File.WriteAllBytesAsync(newPath, image);
            DirectoryInfo directoryInfo = new DirectoryInfo(_baseURL);
            return Path.Combine(directoryInfo.Name, filename);
        }
    }
}

namespace DemoApp.Service.Interfaces
{
    public interface IImageManager
    {
        public Task<string> ComposeAsync(string path);
    }
}

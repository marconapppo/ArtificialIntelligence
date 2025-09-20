
namespace ArtificialIntelligence.Service.Services
{
    public interface IOpenAiService
    {
        Task<FileStream> GetImage(string prompt, string apiKey);
    }
}
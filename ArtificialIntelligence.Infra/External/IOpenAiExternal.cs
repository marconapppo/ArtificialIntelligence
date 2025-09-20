using OpenAI.Images;
using System.ClientModel;

namespace ArtificialIntelligence.Infra.External
{
    public interface IOpenAiExternal
    {
        Task<ClientResult<GeneratedImage>> GetImage(string prompt, string apiKey);
    }
}
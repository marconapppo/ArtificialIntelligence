using ArtificialIntelligence.Domain.Models.External;
using Newtonsoft.Json;
using System;
using OpenAI.Images;

namespace ArtificialIntelligence.Infra.External;

public class OpenAiExternal : IOpenAiExternal
{
    private readonly HttpClient _client;

    public OpenAiExternal(HttpClient client)
    {
        _client = client;
    }

    public async Task<System.ClientModel.ClientResult<GeneratedImage>> GetImage(string prompt, string apiKey)
    {
        ImageClient client = new("gpt-image-1", apiKey);

        ImageEditOptions options = new ImageEditOptions()
        {
            ResponseFormat = GeneratedImageFormat.Bytes,
            Size = GeneratedImageSize.W1024xH1024
        };

        return await client.GenerateImageEditAsync("car.jpg", prompt, options);
    }
}
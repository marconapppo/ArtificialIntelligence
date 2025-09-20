using ArtificialIntelligence.Infra.External;
using System;

namespace ArtificialIntelligence.Service.Services;

public class OpenAiService : IOpenAiService
{
    private readonly IOpenAiExternal _openAiExternal;

    public OpenAiService(IOpenAiExternal openAiExternal)
    {
        _openAiExternal = openAiExternal;
    }

    public async Task<FileStream> GetImage(string prompt, string apiKey)
    {
        var result = await _openAiExternal.GetImage(prompt, apiKey);

        using FileStream stream = File.OpenWrite("imagemOpenAi.png");
        await result.Value.ImageBytes.ToStream().CopyToAsync(stream);

        return stream;
    }
}
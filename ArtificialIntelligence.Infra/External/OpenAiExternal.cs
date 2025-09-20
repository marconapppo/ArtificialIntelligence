using ArtificialIntelligence.Domain.Models.External;
using Newtonsoft.Json;
using OpenAI.Images;
using System;
using System.Runtime.ConstrainedExecution;

namespace ArtificialIntelligence.Infra.External;

public class OpenAiExternal : IOpenAiExternal
{

    public async Task<System.ClientModel.ClientResult<GeneratedImage>> GetImage(string prompt, string apiKey)
    {
        var imagemPath = "C:\\codigos_pessoais\\ArtificialIntelligence\\ArtificialIntelligence.Infra\\External\\car.jpg";

        ImageClient client = new("gpt-image-1", apiKey);

        ImageEditOptions options = new ImageEditOptions()
        {
            //ResponseFormat = GeneratedImageFormat.Bytes,
            //Size = GeneratedImageSize.W1024xH1024
        };

        return await client.GenerateImageEditAsync(imagemPath, prompt, options);
    }
}
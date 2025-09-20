using ArtificialIntelligence.Domain.Models.External;
using Newtonsoft.Json;
using System;

namespace ArtificialIntelligence.Infra.External;

public class OpenAiExternal
{
    private readonly HttpClient _client;

    public OpenAiExternal(HttpClient client)
    {
        _client = client;
    }

    public async Task<OpenAIExternalResponse> GetImage(string apiKey)
    {
        _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var url = $"https://api.openai.com/v1/images/edits";
        try
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            string responseBody = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OpenAIExternalResponse>(responseBody)!;
        }
        catch (Exception ex)
        {

            throw new HttpRequestException($"[COMMISION PROXY][ERROR] Error on get all analytical report. {ex.ContentError ?? ex.Message}");
        }
    }
}
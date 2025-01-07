using OpenAI.Chat;
using OpenAI.Images;

namespace PostAutomateAI.AI;

public static class AutomateAI
{
    public static async Task<string> ResponseAI(string apiKey)
    {
        ChatClient client = new("gpt-4o-mini", apiKey);

        string prompt = @"Pense em temas relacionados aos produtos da loja SPforros e divisórias.
        Após isso, escolha um tema e desenvolva melhor para que isso seja disponibilizado em um blog. Faça o texto com uma estrutura limpa sem parecer um robo,
        use palavras chaves dentro do texto que atraiam clientes que buscam algum produto do mesmo meio, além disso use informações que o proprio site oferece.";
        
        ChatCompletion completion = await client.CompleteChatAsync(prompt);    
        return completion.Content[0].Text;
    }
    public static async Task<(bool, BinaryData?)> GenerateImageAI(string prompt, string apiKey)
    {
        ImageClient client = new("dall-e-3", apiKey);
        ImageGenerationOptions options = new()
        {
            Quality = GeneratedImageQuality.High,
            Size = GeneratedImageSize.W1792xH1024,
            Style = GeneratedImageStyle.Vivid,
            ResponseFormat = GeneratedImageFormat.Bytes
        };
        try
        {
            GeneratedImage image = await client.GenerateImageAsync(prompt, options);
            BinaryData bytes = image.ImageBytes;
            return (true, bytes);
        }
        catch (Exception e)
        {            
            return (false, null);
        }
    }
}

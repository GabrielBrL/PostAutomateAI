using PostAutomateAI.AI;
using PostAutomateAI.Api.IServices;

namespace PostAutomateAI.Api.Services;

public class PromptService : IPromptService
{
    private IConfiguration _config;

    public PromptService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<(bool, BinaryData?)> GenerateImageAI(string prompt)
    {
        return await AutomateAI.GenerateImageAI(prompt, _config.GetValue<string>("OpenAISecret"));
    }

    public async Task<string> ResponseAI()
    {
        return await AutomateAI.ResponseAI(_config.GetValue<string>("OpenAISecret"));
    }

}

using PostAutomateAI.Api.IServices;
using PostAutomateAI.Api.Services;

namespace PostAutomateAI.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPromptService, PromptService>();
        return services;
    }
}

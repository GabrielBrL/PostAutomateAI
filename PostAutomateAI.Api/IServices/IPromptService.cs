namespace PostAutomateAI.Api.IServices;

public interface IPromptService
{
    Task<string> ResponseAI();
    Task<(bool success, BinaryData? binaryData)> GenerateImageAI(string prompt);
}

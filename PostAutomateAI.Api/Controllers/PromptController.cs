using Microsoft.AspNetCore.Mvc;
using PostAutomateAI.Api.IServices;

namespace PostAutomateAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PromptController : ControllerBase
{
    private readonly IPromptService _promptService;

    public PromptController(IPromptService promptService)
    {
        _promptService = promptService;
    }

    [HttpPost("describe")]
    public async Task<string> DescribePost()
    {
        return await _promptService.ResponseAI();
    }
    [HttpPost("generateImage")]
    public async Task<IActionResult> GenerateImage(string prompt)
    {
        var result = await _promptService.GenerateImageAI(prompt);
        if (result.success)
        {
            return File(result.binaryData.ToArray(), "image/png", $"{Guid.NewGuid()}.png");
        }
        return null;
    }
}

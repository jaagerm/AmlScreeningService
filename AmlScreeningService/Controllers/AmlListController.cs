using AmlScreeningService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmlScreeningService.Controllers;

[ApiController]
[Route("[controller]")]
public class AmlListController : ControllerBase
{
    private readonly IAmlListChecker amlListChecker;

    public AmlListController(IAmlListChecker amlListChecker)
    {
        this.amlListChecker = amlListChecker;
    }
    
    [HttpGet]
    public IActionResult GetIfSanctioned(string name)
    {
        var result = amlListChecker.IsMatched(name);
        
        return Ok(result);
    }
}
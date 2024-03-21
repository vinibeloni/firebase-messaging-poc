using Microsoft.AspNetCore.Mvc;

namespace FrebasePushNotification;

[ApiController]
[Route("[controller]")]
public class DeviceController(IRepository repository) : ControllerBase
{
    private readonly IRepository _repository = repository;

    [HttpPut()]
    public IActionResult UpsertDevice([FromBody] Device device)
    {
        _repository.UpsertDevice(device);
        return Ok();
    }

    [HttpGet("{userId}")]
    public Device? GetDevice([FromRoute] string userId)
    {
        return _repository.GetDevice(userId);
    }
}
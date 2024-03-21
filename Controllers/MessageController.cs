using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace FrebasePushNotification;

[ApiController]
[Route("[controller]")]
public class MessageController(IRepository repository, IFirebaseService firebaseService) : ControllerBase
{
    private readonly IRepository _repository = repository;
    private readonly IFirebaseService _firebaseService = firebaseService;

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] MessageRequest request)
    {
        var device = _repository.GetDevice(request.UserId);
        if (device == null) return NotFound("Device not found");

        var sent = await _firebaseService.Send(device, request);

        return sent
            ? Ok("Message sent successfully!")
            : Conflict("Error sending the message.");
    }
}
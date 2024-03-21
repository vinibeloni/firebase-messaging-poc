using FirebaseAdmin.Messaging;

namespace FrebasePushNotification;

public interface IFirebaseService
{
    Task<bool> Send(Device device, MessageRequest request);
}

public class FirebaseService : IFirebaseService
{
    public async Task<bool> Send(Device device, MessageRequest request)
    {
        var message = new Message()
        {
            Token = device.Token,
            Notification = new()
            {
                Title = request.Title,
                Body = request.Body,
            },
            Data = new Dictionary<string, string>{
                { "goTo", "/page2" },
            }
        };

        var result = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        return !string.IsNullOrWhiteSpace(result);
    }
}
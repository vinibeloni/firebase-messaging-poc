namespace FrebasePushNotification;

public record MessageRequest(
    string UserId,
    string Title,
    string Body
);
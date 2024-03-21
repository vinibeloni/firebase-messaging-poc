namespace FrebasePushNotification;

public interface IRepository
{
    void UpsertDevice(Device device);
    Device? GetDevice(string userId);
}

public class InMemoryRepository : IRepository
{
    private readonly Dictionary<string, Device> _devices = [];

    public void UpsertDevice(Device device)
    {
        _devices[device.UserId!] = device;
    }

    public Device? GetDevice(string userId)
    {
        return _devices.GetValueOrDefault(userId);
    }
}

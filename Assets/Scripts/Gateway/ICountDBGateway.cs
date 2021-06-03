namespace SCA
{
    // IGateway
    // Interface for Gateway
    public interface ICountDBGateway
    {
        void SetCount(CountType type, int new_value);
        int GetCount(CountType type);
    }
}

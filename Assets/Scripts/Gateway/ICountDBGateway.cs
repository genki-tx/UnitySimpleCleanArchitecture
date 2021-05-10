namespace SCA
{
    //IGateway
    public interface ICountDBGateway
    {
        void SetCount(CountType type, int new_value);
        int GetCount(CountType type);
    }
}

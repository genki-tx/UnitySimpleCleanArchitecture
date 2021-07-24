using UniRx;
namespace SCA
{
    // IPresenter
    // Interface for Presenter
    public interface ICountPresenter
    {
        // Reactive properties to publish each counter's update
        IReadOnlyReactiveProperty<int> CountA { get; }
        IReadOnlyReactiveProperty<int> CountB { get; }

        // Method to increase specified type's counter
        // You can get the result of the count by CountA or CountB reactive property
        void IncrementCount(CountType type);
    }
}
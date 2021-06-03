using UniRx;
namespace SCA
{
    // IPresenter
    // Interface for Presenter
    public interface ICountPresenter
    {
        ReactiveProperty<int> CountA { get; }
        ReactiveProperty<int> CountB { get; }
        void IncrementCount(CountType type);
    }
}
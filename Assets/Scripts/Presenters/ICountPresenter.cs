using UniRx;
namespace SCA
{
    //IPresenter
    public interface ICountPresenter
    {
        ReactiveProperty<int> CountA { get; }
        ReactiveProperty<int> CountB { get; }
        void IncrementCount(CountType type);
    }
}
using System.Collections.Generic;
using UniRx;

namespace SCA
{
    // IUsecase
    // Interface for Usecase
    public interface ICountUsecase
    {
        // Reactive properties to publish each counter's update
        IReadOnlyReactiveProperty<Dictionary<CountType, Count>> Counts { get; } // pair of <count type, count object>

        // Method to increase specified type's counter
        // You can get the result of the count by CountA or CountB reactive property
        void IncrementCount(CountType type);
    }
}
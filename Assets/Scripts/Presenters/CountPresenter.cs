using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace SCA
{
    // Presenter
    // Presenter can depend on Usecase through its interface
    // Presenter can't dependent on View, Gateway
    // Presenter can inherit Monobehaviour
    public class CountPresenter : MonoBehaviour, ICountPresenter
    {
        public IReadOnlyReactiveProperty<int> CountA => _countA;
        private readonly ReactiveProperty<int> _countA = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> CountB => _countB;
        private readonly ReactiveProperty<int> _countB = new ReactiveProperty<int>();

        // Dependency
        private ICountUsecase _usecase;

        public void Initialize(ICountUsecase usecase)
        {
            _usecase = usecase;

            // Start subscribing reactive property
            var disposable = _usecase.Counts.Subscribe((dict) =>
            {
                // This lambda-function here will be called when _usecase.Counts reactive property updated
                UpdateCount(dict);
            });

            // ... and update initialize by the current value
            UpdateCount(_usecase.Counts.Value);
        }

        private void UpdateCount(Dictionary<CountType, Count> dict)
        {
            foreach (var element in dict)
            {
                switch (element.Key)
                {
                    case CountType.A:
                        _countA.Value = element.Value.Num;
                        break;
                    case CountType.B:
                        _countB.Value = element.Value.Num;
                        break;
                    default:
                        break;
                }
            }
        }

        public void IncrementCount(CountType type)
        {
            _usecase.IncrementCount(type);
        }
    }
}
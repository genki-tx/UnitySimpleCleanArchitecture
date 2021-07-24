using System.Collections.Generic;
using UniRx;

namespace SCA
{
    // Usecase
    // Usecase can depend on Gateway through its interface.
    // Usecase can't be dependent on View, Presenter
    // Usecase can't inherit Monobehaviour
    public class CountUsecase : ICountUsecase
    {
        // Reactive Properties
        public IReadOnlyReactiveProperty<Dictionary<CountType, Count>> Counts => _counts;
        private readonly ReactiveProperty<Dictionary<CountType, Count>> _counts;

        // Dependency
        private readonly ICountDBGateway _gateway;

        public CountUsecase(ICountDBGateway gateway)
        {
            _gateway = gateway;

            // Initialize reactive property
            _counts = new ReactiveProperty<Dictionary<CountType, Count>>(new Dictionary<CountType, Count>());
            InitCount(CountType.A);
            InitCount(CountType.B);
        }

        private void InitCount(CountType type)
        {
            var count = new Count()
            {
                Type = type,
                Num = _gateway.GetCount(type)
            };
            _counts.Value.Add(type, count);
        }

        public void IncrementCount(CountType type)
        {
            var current = _gateway.GetCount(type);
            var new_count = current + 1;
            _gateway.SetCount(type, new_count);

            // publish the value changed
            var dict = _counts.Value;
            dict[type].Num = new_count;
            _counts.SetValueAndForceNotify(dict);
        }

        public int GetCount(CountType type)
        {
            return _gateway.GetCount(type);
        }
    }
}
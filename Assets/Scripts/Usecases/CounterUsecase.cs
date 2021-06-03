using System;
namespace SCA
{
    // Usecase
    // Usecase can depend on Gateway through its interface.
    // Usecase can't be dependent on View, Presenter
    // Usecase can't inherit Monobehaviour
    public class CounterUsecase : ICounterUsecase
    {
        public EventHandler<CounterEventArgs> OnCountChanged { get; set; }
        private readonly ICountDBGateway _gateway;

        public CounterUsecase(ICountDBGateway gateway)
        {
            _gateway = gateway;
        }

        public void IncrementCount(CountType type)
        {
            var current = _gateway.GetCount(type);
            var new_count = current + 1;
            _gateway.SetCount(type, new_count);

            // publish the value changed
            OnCountChanged.Invoke(this, new CounterEventArgs(type, new_count));
        }
        public int GetCount(CountType type)
        {
            return _gateway.GetCount(type);
        }
    }
}

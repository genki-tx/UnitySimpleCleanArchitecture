using UnityEngine;
using UniRx;

namespace SCA
{
    //Presenter
    public class CountPresenter : MonoBehaviour, ICountPresenter
    {
        public ReactiveProperty<int> CountA { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> CountB { get; private set; } = new ReactiveProperty<int>();

        private ICounterUsecase _usecase;

        void Start()
        {
            _usecase = CounterDI.CounterUsecase;

            // Connect callback event to reactive property
            _usecase.OnCountChanged += OnCountChanged;
        }

        public void IncrementCount(CountType type)
        {
            _usecase.IncrementCount(type);
        }

        void OnCountChanged(object sender, CounterEventArgs event_arg)
        {
            if(event_arg.Type == CountType.A)
            {
                CountA.Value = event_arg.Count;
            }
            else if (event_arg.Type == CountType.B)
            {
                CountB.Value = event_arg.Count;
            }
        }
    }
}
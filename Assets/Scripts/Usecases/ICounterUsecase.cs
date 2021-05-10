using System;

namespace SCA
{
    //IUsecase
    public interface ICounterUsecase
    {
        void IncrementCount(CountType type);
        int GetCount(CountType type);
        EventHandler<CounterEventArgs> OnCountChanged { get; set; }
    }

    public class CounterEventArgs : EventArgs
    {
        public CounterEventArgs(CountType type, int count_number)
        {
            Type = type;
            Count = count_number;
        }
        public CountType Type { get; set; }
        public int Count { get; set; }
    }
}

namespace SCA
{
    public enum CountType : int
    {
        A, B
    }

    //Entity
    public class Count
    {
        public CountType Type { get; set; } // type of this count
        public int Num { get; set; } // numlber of count
    }
}

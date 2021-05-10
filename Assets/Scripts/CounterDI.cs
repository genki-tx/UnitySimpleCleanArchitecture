namespace SCA
{
    // Dependency Injection
    public class CounterDI
    {
        public static ICounterUsecase CounterUsecase { get; private set; }
        public static ICountDBGateway CountDBGateway { get; private set; }

        static CounterDI()
        {
            CountDBGateway = new CountDB();
            CounterUsecase = new CounterUsecase(CountDBGateway);
        }
    }
}
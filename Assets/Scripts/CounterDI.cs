namespace SCA
{
    // Dependency Injection
    // You can call static methods in this class to get object for your dependency injection.
    // This design pattern is known as "Service Locator Design Pattern"
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
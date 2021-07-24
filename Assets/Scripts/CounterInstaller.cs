using Zenject;
namespace SCA
{
    // Dependency Injection
    // You can call static methods in this class to get object for your dependency injection.
    // This design pattern is known as "Service Locator Design Pattern"
    public class CounterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Instantiate objects
            var gateway = new CountDBGateway();
            var usecase = new CountUsecase(gateway);
            var presenter = gameObject.AddComponent<CountPresenter>();
            presenter.Initialize(usecase); // since presenter inheritates Monobihavior, you can't inject the dependency by constructor

            // And assign for injection
            Container
                .Bind<ICountDBGateway>()
                .FromInstance(gateway);

            Container
                .Bind<ICountUsecase>()
                .FromInstance(usecase);

            Container
                .Bind<ICountPresenter>()
                .FromInstance(presenter);
        }
    }
}
using UnityEngine;
namespace SCA
{
    // Dependency Injection
    // You can call static methods in this class to get object for your dependency injection.
    // This design pattern is known as "Service Locator Design Pattern"
    public class PresenterDI : MonoBehaviour
    {
        public static ICountPresenter CountPresenter;
        void Awake()
        {
            CountPresenter = gameObject.AddComponent<CountPresenter>();
        }
    }
}
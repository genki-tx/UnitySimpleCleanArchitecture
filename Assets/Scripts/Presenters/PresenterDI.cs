using UnityEngine;
namespace SCA
{
    public class PresenterDI : MonoBehaviour
    {
        public static ICountPresenter CountPresenter;
        void Awake()
        {
            CountPresenter = gameObject.AddComponent<CountPresenter>();
        }
    }
}
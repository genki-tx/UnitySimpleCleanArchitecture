using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountButtonView : MonoBehaviour
    {
        public CountType Type;

        private ICountPresenter _presenter;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            _presenter = PresenterDI.CountPresenter;

            _button.onClick.AddListener(() => {
                _presenter.IncrementCount(Type);
            });
        }
    }
}
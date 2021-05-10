using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    //View
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
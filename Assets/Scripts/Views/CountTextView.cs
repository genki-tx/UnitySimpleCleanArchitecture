using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountTextView : MonoBehaviour
    {
        public CountType Type;

        private ICountPresenter _presenter;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            _presenter = PresenterDI.CountPresenter;
            var reactive_property = Type == CountType.A ? _presenter.CountA : _presenter.CountB;

            reactive_property.Subscribe((x) =>
            {
                UpdateText(x);
            }).AddTo(this);

            UpdateText(0); // Initialize
        }

        private void UpdateText(int count)
        {
            _text.text = string.Format("Count {0} = {1}", Type.ToString(), count);
        }
    }
}
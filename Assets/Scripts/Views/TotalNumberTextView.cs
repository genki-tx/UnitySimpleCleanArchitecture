using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class TotalNumberTextView : MonoBehaviour
    {
        [Inject]
        private ICountPresenter _presenter;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            _presenter.CountA.Subscribe((x) => { UpdateCount(); }).AddTo(this);
            _presenter.CountB.Subscribe((x) => { UpdateCount(); }).AddTo(this);
        }

        private void UpdateCount()
        {
            var a = _presenter.CountA.Value;
            var b = _presenter.CountB.Value;
            var total = a + b;
            _text.text = string.Format("Total = {0}", total);
        }
    }
}
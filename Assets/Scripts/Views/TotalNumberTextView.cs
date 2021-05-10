using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace SCA
{
    //View
    public class TotalNumberTextView : MonoBehaviour
    {
        private ICountPresenter _presenter;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            _presenter = PresenterDI.CountPresenter;
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
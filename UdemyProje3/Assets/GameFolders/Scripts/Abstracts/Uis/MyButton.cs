using UnityEngine;
using UnityEngine.UI;

namespace UdemyProje3.Abstracts.Uis
{
    public abstract class MyButton : MonoBehaviour
    {
        Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
        protected abstract void HandleOnButtonClicked();
    }
}



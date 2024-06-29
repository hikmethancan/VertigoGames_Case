using _Main.Scripts.Base.MonoBehaviourBase;
using UnityEngine.UI;

namespace _Main.Scripts.UserInterface.Buttons.Abstract
{
    public abstract class ButtonsBase : Operator
    {
        private Button _button;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                _button.onClick.AddListener(OnButtonClicked);
            else
                _button.onClick.RemoveListener(OnButtonClicked);
        }

        protected override void Setup()
        {
            TryGetComponent(out _button);
        }

        protected virtual void OnButtonClicked()
        {
        }

        protected void SetInteractable(bool value)
        {
            _button.interactable = value;
        }
    }
}
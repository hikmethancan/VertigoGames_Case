using _Main.Scripts.SceneSystem.Concrete;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class ExitButton : ButtonsBase
    {
        [SerializeField] private ExitButtonSo exitButtonSo;

        protected override void OnButtonClicked()
        {
            ExitAction();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnExitButtonActivate += ReadyForExit;
            else
                GameSignals.OnExitButtonActivate -= ReadyForExit;
        }

        private void ReadyForExit(bool activate)
        {
            SetInteractable(activate);
            if (activate)
                ScaleUpButton();
            else
                ScaleDownButton();
        }

        private void ExitAction()
        {
            GameSignals.OnExitTheGame?.Invoke();
            SetInteractable(false);
            SceneHandler.LoadMenuScene();
        }

        private void ScaleUpButton()
        {
            SetInteractable(false);
            transform.DOComplete();
            transform.DOScale(Vector3.one, exitButtonSo.scaleDuration).SetEase(exitButtonSo.scaleUpEase)
                .OnComplete(() => { SetInteractable(true); })
                ;
        }

        private void ScaleDownButton()
        {
            SetInteractable(false);
            transform.DOComplete();
            transform.DOScale(Vector3.zero, exitButtonSo.scaleDuration).SetEase(exitButtonSo.scaleDownEase);
        }
    }
}
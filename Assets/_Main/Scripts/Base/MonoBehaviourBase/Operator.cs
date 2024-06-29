using System;
using UnityEngine;

namespace _Main.Scripts.Base.MonoBehaviourBase
{
    public abstract class Operator : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            Register(true);
        }

        protected void OnDisable()
        {
            Register(false);
        }

        protected virtual void Awake() => Init();


        protected abstract void Setup();

        private void Init()
        {
            Setup();
        }

        protected virtual void Register(bool isActive)
        {
        }
    }
}
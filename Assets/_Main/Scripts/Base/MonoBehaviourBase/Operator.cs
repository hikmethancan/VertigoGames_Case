using System;
using UnityEngine;

namespace _Main.Scripts.Base.MonoBehaviourBase
{
    public class Operator : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            Register(true);
        }

        protected void OnDisable()
        {
            Register(false);
        }

        protected virtual void Register(bool isActive)
        {
        }
    }
}
using UnityEngine;

namespace _Main.Scripts.StateMachine.Abstract
{
    public abstract class BaseState <T> where T: BaseStateManager<T>
    {
        [Header("Privates")]
        protected T _context;

        protected BaseState(T context)
        {
            _context = context;
        }

        public abstract void EnterState();

        public abstract void UpdateState();

        public abstract void ExitState();
    }
}
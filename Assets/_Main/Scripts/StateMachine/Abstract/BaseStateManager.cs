using System;
using _Main.Scripts.Base.MonoBehaviourBase;
using UnityEngine;

namespace _Main.Scripts.StateMachine.Abstract
{
    public abstract class BaseStateManager<T> : Operator where T : BaseStateManager<T>
    {
        [Header("Base - General Variables")] [SerializeField]
        protected bool _isInitializeOnStart;

        [Header("Privates")] protected BaseState<T> _currentState;

        protected Transform _transform;
        protected BaseState<T> _initialState;

        #region Properties

        public BaseState<T> CurrentState => _currentState;
        public Transform Transform => _transform;

        #endregion

        #region Actions

        public Action<BaseState<T>> OnStateChanged;

        #endregion

        protected virtual void Awake()
        {
            _transform = transform;

            InitializeStates();
        }

        protected virtual void Start()
        {
            if (!_isInitializeOnStart) return;

            StartStateMachine();
        }

        protected virtual void Update()
        {
            HandleStateUpdate();
        }

        protected abstract void InitializeStates();

        protected virtual void HandleStateUpdate()
        {
            if (_currentState == null) return;

            _currentState.UpdateState();
        }

        protected virtual void StartStateMachine()
        {
            _currentState = _initialState;
            _currentState.EnterState();
            OnStateChanged?.Invoke(_currentState);
        }

        //Use when activation needs to an event listener
        protected virtual void OnActivation()
        {
            StartStateMachine();
        }

        protected virtual void OnDeActivation()
        {
        }

        public virtual void SwitchState(BaseState<T> state)
        {
            _currentState?.ExitState();
            _currentState = state;
            _currentState.EnterState();
            OnStateChanged?.Invoke(_currentState);
        }
    }
}
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelController : Operator
    {
        [SerializeField] private WheelControllerSo wheelControllerSo;
        protected override void Setup()
        {
            
        }
    }
}
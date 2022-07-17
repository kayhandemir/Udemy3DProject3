using UdemyProje3.Abstracts.States;
using UdemyProje3.Abstracts.Controllers;
using UnityEngine;

namespace UdemyProje3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnEnter)}");

            _enemyController.Dead.DeadAction();
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
            _enemyController.Animation.DeadAnimation("dying");   
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
        }

        public void Tick()
        {
            return;
        }

        public void TickFixed()
        {
            return;
        }

        public void TickLate()
        {
            return;
        }
    }
}




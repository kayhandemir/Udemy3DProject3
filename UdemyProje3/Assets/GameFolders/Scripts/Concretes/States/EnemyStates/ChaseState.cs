using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.States;
using UnityEngine;

namespace UdemyProje3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;
        IEnemyController _enemyController;
        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
            _enemyController.Mover.MoveAction(_enemyController.transform.position, 0f);
        }
        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _speed);
        }
        public void TickFixed()
        {
            _enemyController.FindNearestTarget();
        }
        public void TickLate()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}


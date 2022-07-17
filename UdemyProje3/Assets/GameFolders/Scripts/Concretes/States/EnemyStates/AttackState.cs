using UdemyProje3.Abstracts.States;
using UdemyProje3.Abstracts.Controllers;
using UnityEngine;

namespace UdemyProje3.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;
        public AttackState(IEnemyController enemenyController)
        {
            _enemyController = enemenyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnExit)}");
            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f); ;
        }

        public void TickFixed()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
            _enemyController.FindNearestTarget();
        }
        public void TickLate()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}



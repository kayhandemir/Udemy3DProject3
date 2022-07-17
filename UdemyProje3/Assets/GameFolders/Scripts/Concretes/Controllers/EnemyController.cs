using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Animations;
using UdemyProje3.Combats;
using UdemyProje3.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;
using UdemyProje3.Managers;
using UdemyProje3.Movements;

namespace UdemyProje3.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        IHealth _health;
        NavMeshAgent _agent;
        StateMachine _stateMachine;
        public IMover Mover { get; private set; }
        public InventoryController Inventory { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public Transform Target { get; set; }
        public Dead Dead { get; private set; }
        public float Magnitude => _agent.velocity.magnitude;
        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <= _agent.stoppingDistance && _agent.velocity == Vector3.zero;
        private void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            _stateMachine = new StateMachine();
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            Inventory = GetComponent<InventoryController>();
            Dead = GetComponent<Dead>();
        }
        private void Start()
        {
            FindNearestTarget();
            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);
            _stateMachine.SetState(chaseState);
        }
        public void FindNearestTarget()
        {      
            Transform nearest = EnemyManager.Instance.Targets[0];
            foreach (Transform target in EnemyManager.Instance.Targets)
            {
                float nearestValue = Vector3.Distance(nearest.position, this.transform.position);
                float newValue = Vector3.Distance(target.position, transform.position);
                if (newValue < nearestValue)
                {
                    nearest = target;
                }
            }
            Target = nearest;
        }
        private void Update()
        {
            _stateMachine.Tick();
        }
        void FixedUpdate()
        {
            if (CanAttack)
            {
                _stateMachine.TickFixed();
            }
        }
        void LateUpdate()
        {
            _stateMachine.TickLate();
        }
        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }
    }
}


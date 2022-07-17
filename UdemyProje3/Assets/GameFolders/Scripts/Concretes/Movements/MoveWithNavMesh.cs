using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProje3.Movements
{
    public class MoveWithNavMesh : IMover
    {
        NavMeshAgent _navMeshAgent;
        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }
        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            _navMeshAgent.SetDestination(direction);
            //_navMeshAgent.speed = moveSpeed;
        }
    }
}


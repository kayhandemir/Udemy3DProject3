using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;
        public MoveWithCharacterController(IEntityController entityController)
        {
            _characterController = entityController.transform.GetComponent<CharacterController>();
        }
        public void MoveAction(Vector3 direction,float _moveSpeed)
        {
            if (direction.magnitude==0f) return;
            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * _moveSpeed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }

}


using UnityEngine;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Controllers;

namespace UdemyProje3.Movements
{
    public class RotatorYCharacter : IRotator
    {
        Transform _transform;
        float _tilt;
        public RotatorYCharacter(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }
        public void RotationAction(float direction,float speed)
        {
             direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -5f, 10f);
            _transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
        }
    }
}
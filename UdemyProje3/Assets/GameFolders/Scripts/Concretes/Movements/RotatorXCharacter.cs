using UnityEngine;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Controllers;

namespace UdemyProje3.Movements
{
    public class RotatorXCharacter : IRotator
    {
        PlayerController controller;
        public RotatorXCharacter(PlayerController playerController)
        {
            controller = playerController;
        }
        public void RotationAction(float direction, float speed)
        {
            controller.transform.Rotate(Vector3.up * direction * Time.deltaTime * speed);
        }
    }
}

using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class RibRotator : IRotator
    {
        Transform _transform;
        float _tilt;
        public RibRotator(Transform transform)
        {
            _transform = transform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -5f, 10f);
            _transform.Rotate(new Vector3(0, 0, _tilt));
        }
    }
}

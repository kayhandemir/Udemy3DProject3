using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Managers;
using UdemyProje3.ScriptableObjects;
using UnityEngine;

namespace UdemyProje3.Combats
{
    public class MeleeAttackType : IAttackType
    {
        Transform _transformObject;
        AttackSO _attackSo;
        public MeleeAttackType(Transform transform,AttackSO attackSO)
        {
            _transformObject = transform;
            _attackSo = attackSO;
        }
        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSo.FloatValue, _attackSo.Layer);
            foreach (Collider item in colliders)
            {
                if (item.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSo.Damage);
                }
            }
            SoundManager.Instance.MeleeAttackSound(_attackSo.Clip, _transformObject.position);
        }
    }
}

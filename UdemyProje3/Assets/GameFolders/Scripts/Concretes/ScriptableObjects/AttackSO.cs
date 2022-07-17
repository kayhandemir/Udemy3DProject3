using UnityEngine;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Combats;

namespace UdemyProje3.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Attack Info",menuName = "Combat/Attack Information/Create New",order =51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] int _damage;
        [SerializeField] float _floatValue;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay;
        [SerializeField] AnimatorOverrideController _animatorOverride;
        [SerializeField] AudioClip _clip;
        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask Layer => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;
        public AudioClip Clip => _clip;
        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType==AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform,this);
            }
            else
            {
                return new MeleeAttackType(transform,this);
            }
        }
    }
}


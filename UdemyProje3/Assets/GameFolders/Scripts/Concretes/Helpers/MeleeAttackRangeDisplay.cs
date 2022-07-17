using UdemyProje3.ScriptableObjects;
using UnityEngine;

namespace UdemyProje3.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSo;
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _attackSo.FloatValue);
        }
    }
}


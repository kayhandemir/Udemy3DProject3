using UdemyProje3.Abstracts.Combats;
using UdemyProje3.ScriptableObjects;
using UnityEngine;

namespace UdemyProje3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] HealthSO _healthInfo;
        int _currentHealth;
        public event System.Action<int, int> OnTakeHit;
        public event System.Action OnDead;
        public bool IsDead => _currentHealth <= 0;
        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealht;
        }
        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            _currentHealth -= damage;
            OnTakeHit?.Invoke(_currentHealth,_healthInfo.MaxHealht);
            if (IsDead)
            {
                OnDead?.Invoke();
            }
        }
    }
}

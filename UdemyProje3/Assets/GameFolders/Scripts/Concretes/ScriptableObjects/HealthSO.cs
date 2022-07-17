using UnityEngine;

namespace UdemyProje3.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Health Info",menuName = "Combat/Health Information/Create New",order =51)]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] int _maxHealht;
        public int MaxHealht => _maxHealht;
    }
}


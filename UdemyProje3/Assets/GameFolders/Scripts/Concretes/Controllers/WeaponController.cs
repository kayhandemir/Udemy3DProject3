using UdemyProje3.Abstracts.Combats;
using UdemyProje3.ScriptableObjects;
using UnityEngine;

namespace UdemyProje3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] Transform _attackPoint;
        [SerializeField] AttackSO _attackSo;
        [SerializeField] bool _canFire;
        //[SerializeField] Camera _camera;
        float _currentTime = 0f;
        IAttackType _attackType;
        public AttackSO AttackSO => _attackSo;
        private void Awake()
        {
            _attackType = _attackSo.GetAttackType(_attackPoint);
        }
        private void Update()
        {
            _currentTime += Time.deltaTime;
            _canFire = _currentTime >= _attackSo.AttackMaxDelay;
            _attackPoint = GetComponentInChildren<Transform>();
        }
        public void Attack()
        {
            if (!_canFire) return;
            _attackType.AttackAction();
            _currentTime = 0f;
        }
        //public void Attack2()
        //{
        //    if (!_canFire) return;
        //    Ray ray = _camera.ViewportPointToRay(Vector3.one / 2);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, _distance, _layerMask))
        //    {
        //        IHealth health = hit.collider.GetComponent<IHealth>();
        //        health?.TakeDamage(_damage);
        ////      if (hit.collider.TryGetComponent(out IHealth health1)
        ////      {
        ////           health.TakeDamage(_damage);
        ////      }
        //        Debug.Log("Hedefi vurdun!");
        //    }
        //    else
        //    {
        //        Debug.Log("Hedefi Iskaladýn");
        //    }
        //    _currentTime = 0f;
        //}
    }
}


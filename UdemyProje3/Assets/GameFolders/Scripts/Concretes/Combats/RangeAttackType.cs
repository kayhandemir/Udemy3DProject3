using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Managers;
using UdemyProje3.ScriptableObjects;
using UnityEngine;
//using UdemyProje3.Controllers;

namespace UdemyProje3.Combats
{
    public class RangeAttackType :/*MonoBehaviour,*/ IAttackType
    {
        AttackSO _attackSo;
        Transform _attackPoint;
        //public BulletFxController _fxController;
        //private void Start()
        //{
        //    _fxController = GetComponent<BulletFxController>();
        //}
        public RangeAttackType(Transform obj, AttackSO attackSO)
        {
            _attackPoint = obj.GetComponentInChildren<Transform>();
            _attackSo = attackSO;
        }
        public void AttackAction()
        {
            RaycastHit hit;
            if (Physics.Raycast(_attackPoint.transform.position, _attackPoint.TransformDirection(Vector3.forward), out hit,_attackSo.FloatValue,_attackSo.Layer))
            {
                IHealth health = hit.collider.GetComponent<IHealth>();
                health?.TakeDamage(_attackSo.Damage);
                //if (hit.collider.TryGetComponent(out IHealth health1)
                //{
                //    health.TakeDamage(_damage);
                //}
                Debug.Log("Hedefi vurdun!");
                Debug.DrawRay(_attackPoint.transform.position, _attackPoint.TransformDirection(Vector3.forward)*_attackSo.FloatValue, Color.green);
            }
            else
            {
                Debug.Log("Hedefi Iskaladýn");
                Debug.DrawRay(_attackPoint.transform.position, _attackPoint.TransformDirection(Vector3.forward)*_attackSo.FloatValue, Color.red);
            }
            SoundManager.Instance.RangeAttackSound(_attackSo.Clip, _attackPoint.transform.position);
            //Instantiate(_fxController, _attackPoint.transform.position, _attackPoint.rotation);
            //_fxController.SetDirection(Vector3.forward);
        }
    }
}


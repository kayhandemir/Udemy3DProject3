using System.Collections;
using UnityEngine;

namespace UdemyProje3.Combats
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] float _delayTime=5f;
        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {
            yield return new WaitForSeconds(_delayTime);
            Destroy(this.gameObject);
        }
    }
}


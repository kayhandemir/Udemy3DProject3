using UnityEngine;
using UnityEngine.UI;
using UdemyProje3.Combats;
using System;

namespace UdemyProje3.UIs
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healtImage;
        private void Awake()
        {
            _healtImage = GetComponent<Image>();
        }
        private void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += HandleTakeHit;
        }
        private void HandleTakeHit(int currenHealth, int maxHealth)
        {
            _healtImage.fillAmount = Convert.ToSingle(currenHealth) / Convert.ToSingle(maxHealth);
        }
    }
}


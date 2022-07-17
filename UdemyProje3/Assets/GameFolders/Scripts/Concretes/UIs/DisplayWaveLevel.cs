using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UdemyProje3.Managers;
using System;

namespace UdemyProje3.UIs
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        TMP_Text _levelText;
        private void Awake()
        {
            _levelText = GetComponent<TMP_Text>();
        }
        private void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextWave;
        }

        private void HandleOnNextWave(int levelValue)
        {
            _levelText.text = levelValue.ToString();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextWave;
        }
    }
}

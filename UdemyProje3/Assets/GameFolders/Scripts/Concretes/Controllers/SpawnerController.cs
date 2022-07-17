using System;
using UdemyProje3.Managers;
using UdemyProje3.ScriptableObjects;
using UnityEngine;

namespace UdemyProje3.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _swapnInfo;
        [SerializeField] float _maxTime;
        float _currentTime = 0f;
        private void Start()
        {
            _maxTime = _swapnInfo.RandomSpawnMaxTime;
        }
        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _maxTime&&EnemyManager.Instance.CanSpawn&&!GameManager.Instance.IsWaveFinished)
            {
                Spawn();
            }
        }
        private void Spawn()
        {
            EnemyController enemyController= Instantiate(_swapnInfo.EnemyPrefab, transform.position, Quaternion.identity);
            EnemyManager.Instance.AddEnemyController(enemyController);
            _currentTime = 0f;
            _maxTime = _swapnInfo.RandomSpawnMaxTime;
        }
    }
}


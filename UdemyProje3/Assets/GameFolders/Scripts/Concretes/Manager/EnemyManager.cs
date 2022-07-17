using UdemyProje3.Abstracts.Helpers;
using UdemyProje3.Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje3.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] List<EnemyController> _enemies;
        [SerializeField] int _maxCountOnGame = 10;
        public List<Transform> Targets { get; private set; }
        public bool CanSpawn => _maxCountOnGame >= _enemies.Count;
        public bool IsListEmpty => _enemies.Count <= 0;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }
        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {    
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount();
        }
        public void DestoryAllEnemies()
        {
            foreach (EnemyController enemyController in _enemies)
            {
                Destroy(enemyController.gameObject);
            }
            _enemies.Clear();
        }
    }
}


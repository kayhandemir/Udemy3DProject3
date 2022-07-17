using System.Collections;
using UdemyProje3.Abstracts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProje3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] int _waveLevel = 1;
        [SerializeField] float _waitNextLevel = 10f;
        [SerializeField] float _waveMultiple = 1.2f;
        [SerializeField] int _maxWaveBoundryCount = 50;
        [SerializeField] int _playerCount = 0;
        int _currentWaveCount;
        public int PlayerCount => _playerCount;
        public event System.Action<int> OnNextWave;
        public bool IsWaveFinished => _currentWaveCount <= 0;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }
        private void Start()
        {
            _currentWaveCount = _maxWaveBoundryCount;
        }
        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelAsync(name));
        }
        private IEnumerator LoadLevelAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }
        public void DecreaseWaveCount()
        {
            if (IsWaveFinished)
            {
                if (EnemyManager.Instance.IsListEmpty)
                {
                    StartCoroutine(StartNextWaveAsync());
                }          
            }
            else
            {
                _currentWaveCount--;
            }       
        }
        private IEnumerator StartNextWaveAsync()
        {
            yield return new WaitForSeconds(_waitNextLevel);
            _maxWaveBoundryCount = System.Convert.ToInt32(_maxWaveBoundryCount * _waveMultiple);
            _currentWaveCount = _maxWaveBoundryCount;
            _waveLevel++;
            OnNextWave?.Invoke(_waveLevel);
        }
        public void IncreasePlayerCount()
        {
            _playerCount++;
        }
        public void ReturnMenu()
        {
            if (_playerCount>1)
            {
                _playerCount--;
            }
            else
            {
                _playerCount = 0;
                EnemyManager.Instance.DestoryAllEnemies();
                EnemyManager.Instance.Targets.Clear();
                LoadLevelAsync("Menu");
            }
        }
    }
}


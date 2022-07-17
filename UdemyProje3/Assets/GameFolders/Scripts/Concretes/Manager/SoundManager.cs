using UdemyProje3.Abstracts.Helpers;
using UdemyProje3.Controllers;
using UnityEngine;

namespace UdemyProje3.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] AudioClip _clip;
        SoundController[] _soundControllers;
        public SoundController[] Sounds => _soundControllers;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }
        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }
        public void RangeAttackSound(AudioClip clip, Vector3 position)
        {
            _soundControllers[1].PlaySound(position);
            _soundControllers[1].SetClip(clip);
        }
        public void MeleeAttackSound(AudioClip clip,Vector3 position)
        {
            for (int i = 2; i < _soundControllers.Length; i++)
            {
                if (_soundControllers[i].IsPlaying) continue;
                _soundControllers[i].SetClip(clip);
                _soundControllers[i].PlaySound(position);
                break;
            }
        }
    }
}


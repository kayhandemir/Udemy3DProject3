using UnityEngine;
using UdemyProje3.Abstracts.Inputs;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Movements;
using UdemyProje3.Animations;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Managers;

namespace UdemyProje3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("MoveSpeed")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] Transform _ribTransform;
        [Header("Uis")]
        [SerializeField] GameObject _gameOverPanel;
        IInputReader _input;
        IRotator _XRotator;
        IRotator _YRotator;
        IRotator _ribRotator;
        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        InventoryController _inventory;
        Vector3 _direction;
        Vector3 _rotation;
        public Transform TurnTransform => _turnTransform;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _XRotator = new RotatorXCharacter(this);
            _YRotator = new RotatorYCharacter(this);
            _ribRotator = new RibRotator(_ribTransform);
            _inventory = GetComponent<InventoryController>();
            _health = GetComponent<IHealth>();
        }
        private void Update()
        {
            if (_health.IsDead) return;
            _rotation = _input.Rotation;
            _direction = _input.Direction;
            _XRotator.RotationAction(_rotation.x, _turnSpeed);
            _YRotator.RotationAction(_rotation.y, _turnSpeed);
            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }
            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }
        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("death");
                _gameOverPanel.SetActive(true);
            };
            EnemyManager.Instance.Targets.Add(this.transform);
        }
        private void OnDisable()
        {
            _health.OnDead -= () => _animation.DeadAnimation("death");
            EnemyManager.Instance.Targets.Remove(this.transform);
        }
        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            _mover.MoveAction(_direction, _moveSpeed);
        }
        private void LateUpdate()
        {
            if (_health.IsDead) return;
            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPress);
            _ribRotator.RotationAction(_rotation.y*-1f, _turnSpeed);
        }
    }
}


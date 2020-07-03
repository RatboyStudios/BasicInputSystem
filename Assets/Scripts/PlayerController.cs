using UnityEngine;

namespace RatboyStudios.PlayerInput
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {

        private PlayerInput _playerInput;
        private Animator _animator;
       

        private readonly int HashCrouch = Animator.StringToHash("Crouch");
        private readonly int HashAttack = Animator.StringToHash("Attack");
        private readonly int HashVerticalSpeed = Animator.StringToHash("VerticalSpeed");
        private readonly int HashHorizontalSpeed = Animator.StringToHash("HorizontalSpeed");


        private void Start()
        {
            if (!TryGetComponent(out _animator))
            {
                Debug.LogError("MISSING ANIMATOR",this);
            }
            if (!TryGetComponent(out _playerInput))
            {
                Debug.LogError("MISSING PLAYERINPUT",this);
            } 
         
            
        }

        private void Update()
        {
            if (_playerInput.Pause)
            {
                Time.timeScale = 0.0f;
            }
        }

        private void HorizontalMovement()
        {
            _animator.SetFloat(HashHorizontalSpeed,_playerInput.Horizontal);
         

        }

        private void VerticalMovement()
        {
            _animator.SetFloat(HashVerticalSpeed,_playerInput.Vertical);
        }

        private void Crouch()
        {
            _animator.SetBool(HashCrouch,_playerInput.Crouch);
        }
        

        private void FixedUpdate()
        {
            _animator.ResetTrigger(HashAttack);

            if (_playerInput.Attack)
            {
                _animator.SetTrigger(HashAttack);
            }
            HorizontalMovement();
            VerticalMovement();
            Crouch();
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 10f;

    private float _minGravity = -0.5f;
    private float _peakMagnitude;
    private CharacterController _characterController;
    private PlayerAnimation _playerAnimation;
    private Vector3 _velocityDirection;

    public float GravityForce { get; set; } = 9.8f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update() => GravityHandling();

    public void MoveToDestination(Vector3 moveDirection)
    {
        TryOnAnimationRun();
        
        _velocityDirection.x = moveDirection.x * _moveSpeed;
        _velocityDirection.z = moveDirection.z * _moveSpeed;
        
        _characterController.Move(_velocityDirection * Time.deltaTime);
    }

    public void RotateToDestination(Vector3 moveDirection)
    {
        if (_characterController.isGrounded)
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
    }

    public void SetStartJumpVelocity(float startJumpVelocity) => 
        _velocityDirection.y = startJumpVelocity;

    private void TryOnAnimationRun()
    {
        if (_velocityDirection.magnitude > 0)
            if (_peakMagnitude == 0)
                _peakMagnitude = _velocityDirection.magnitude;
            else if (_velocityDirection.magnitude > _peakMagnitude)
                _playerAnimation.OnAnimationRun(true);
            else
                _playerAnimation.OnAnimationRun(false);
    }
    
    private void GravityHandling()
    {
        if (_characterController.isGrounded)
            _velocityDirection.y = _minGravity;
        else
            _velocityDirection.y -= GravityForce * Time.deltaTime;
    }
}
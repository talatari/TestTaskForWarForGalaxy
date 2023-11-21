using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMover2 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private float _gravityForce = 20f;

    private float _currentAttractionCharacter;
    private CharacterController _characterController;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update() => GravityHandling();

    public void MoveToDestination(Vector3 targetDirection)
    {
        _playerAnimation.TransferIsRun(targetDirection != Vector3.zero);
        targetDirection *= _moveSpeed;
        targetDirection.y = _currentAttractionCharacter;
        _characterController.Move(targetDirection * Time.deltaTime);
    }

    public void RotateToDestination(Vector3 targetDirection)
    {
        if (_characterController.isGrounded)
        {
            if (Vector3.Angle(transform.forward, targetDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
    
    private void GravityHandling()
    {
        if (_characterController.isGrounded)
            _currentAttractionCharacter = 0;
        else
            _currentAttractionCharacter -= _gravityForce * Time.deltaTime;
    }
}
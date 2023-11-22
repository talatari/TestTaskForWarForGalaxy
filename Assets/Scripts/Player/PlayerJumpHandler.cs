using UnityEngine;

[RequireComponent(
    typeof(CharacterController),
    typeof(PlayerMover))]

public class PlayerJumpHandler : MonoBehaviour
{
    [SerializeField] private float _maxJumpTime = 0.5f;
    [SerializeField] private float _maxJumpHeight = 2.0f;

    private float _startJumpVelocity;
    private CharacterController _characterController;
    private PlayerMover _playerMover;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerMover = GetComponent<PlayerMover>();

        Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            HandleJump();
    }

    public void HandleJump()
    {
        if (_characterController.isGrounded)
            _playerMover.SetStartJumpVelocity(_startJumpVelocity);
    }
    
    private void Initialize()
    {
        float maxHeightTime = _maxJumpTime / 2;
        float gravityForce = 2 * _maxJumpHeight / (maxHeightTime * maxHeightTime);

        if (gravityForce >= 0)
            _playerMover.GravityForce = gravityForce;

        _startJumpVelocity = 2 * _maxJumpHeight / maxHeightTime;
    }
}
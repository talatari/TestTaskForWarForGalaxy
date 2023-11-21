using UnityEngine;

public class UIJoystickMover : UIJoystickHandler
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private PlayerMover2 _playerMover;

    public void Update()
    {
        if (_playerMover is not null)
        {
            Vector3 point;

            if (_inputVector.x != 0 || _inputVector.y != 0)
                point = new Vector3(_inputVector.x, 0, _inputVector.y);
            else
                point = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

            _playerMover.MoveToDestination(point);
            _playerMover.RotateToDestination(point);
        }
    }
}
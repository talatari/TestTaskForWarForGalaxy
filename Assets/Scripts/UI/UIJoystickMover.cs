using UnityEngine;

public class UIJoystickMover : UIJoystickHandler
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector3 GetVectorDirection()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
            return new Vector3(_inputVector.x, 0, _inputVector.y);
        else
            return new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
    }
}
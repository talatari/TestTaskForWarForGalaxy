using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _returnSpeed = 2f;
    [SerializeField] private float _height = 12f;
    [SerializeField] private float _rearDistance = 9f;

    private Vector3 _currentVector;
    private Vector3 _cameraPosition;

    private void Start()
    {
        _cameraPosition = transform.position;
        
        _cameraPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + _height, _player.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_player.transform.position - _cameraPosition);
    }

    private void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        _currentVector = new Vector3(_player.transform.position.x, _player.transform.position.y + _height, _player.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, _currentVector, _returnSpeed * Time.deltaTime);
    }
}
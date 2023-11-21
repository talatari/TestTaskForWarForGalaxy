using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _returnSpeed = 2f;
    [SerializeField] private float _height = 12f;
    [SerializeField] private float _rearDistance = 9f;

    private Vector3 _currentVector;
    private Vector3 _playerPosition;

    private void Start()
    {
        _playerPosition = _player.transform.position;
        
        transform.position = new Vector3(
            _playerPosition.x, 
            _playerPosition.y + _height, 
            _playerPosition.z - _rearDistance);
        
        transform.rotation = Quaternion.LookRotation(_playerPosition - transform.position);
    }

    private void Update() => CameraMove();

    private void CameraMove()
    {
        _playerPosition = _player.transform.position;
        
        _currentVector = new Vector3(
            _playerPosition.x, 
            _playerPosition.y + _height, 
            _playerPosition.z - _rearDistance);
        
        transform.position = Vector3.Lerp(transform.position, _currentVector, _returnSpeed * Time.deltaTime);
    }
}
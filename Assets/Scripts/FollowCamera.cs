using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _smoothTime = 0.2f;
    [SerializeField] private float _offset = 10;
    
    private Vector3 _velocity = Vector3.zero;

    private void Awake() => _player ??= FindObjectOfType<Player>();

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = _player.transform.position;
        Vector3 targetCameraPosition = new Vector3(playerPosition.x, cameraPosition.y, playerPosition.z - _offset);
        cameraPosition = Vector3.SmoothDamp(cameraPosition, targetCameraPosition, ref _velocity, _smoothTime);
        transform.position = cameraPosition;
    }
}
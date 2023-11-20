using UnityEngine;

[RequireComponent(
   typeof(PlayerAnimation),
   typeof(Rigidbody))]

public class PlayerMover : MonoBehaviour
{
   [SerializeField, Range(0, 10)] private float _moveSpeed = 0.2f;

   private Camera _camera;
   private Transform _transform;
   private PlayerAnimation _playerAnimation;
   private Vector3 _targetMove;

   private void Awake()
   {
      _camera = Camera.main;
      _transform = transform;
      _playerAnimation = GetComponent<PlayerAnimation>();
   }

   private void Update()
   {
      SetMoveTarget();
      
      MoveToTarget();
   }

   private void SetMoveTarget()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out RaycastHit raycastHit))
            _targetMove = raycastHit.point;
      }
   }
   
   private void MoveToTarget()
   {
      if (_targetMove != _transform.position)
      {
         _transform.position = Vector3.MoveTowards(transform.position, _targetMove, _moveSpeed * Time.deltaTime);
         _transform.rotation = Quaternion.LookRotation(_targetMove);
         
         _playerAnimation.TransferSpeed(_transform.position.magnitude);
      }
      else
      {
         _playerAnimation.TransferSpeed(0);
      }
      
   }
}
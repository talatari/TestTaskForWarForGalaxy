using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]

public class PlayerMoverTransformPosition : MonoBehaviour
{
   [SerializeField, Range(0, 10)] private float _moveSpeed = 0.2f;

   private Camera _camera;
   private Transform _transform;
   private PlayerAnimation _playerAnimation;
   private Vector3 _targetMove;
   private Vector3 _oldPosition;

   private void Start()
   {
      _camera = Camera.main;
      _transform = transform;
      _playerAnimation = GetComponent<PlayerAnimation>();
      _oldPosition = _transform.position;
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
         {
            _targetMove = raycastHit.point;
            
            RotateToTarget();
         }
      }
   }

   private void RotateToTarget()
   {
      Vector3 relativePosition = _targetMove - _transform.position;
      _transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
   }

   private void MoveToTarget()
   {
      if (_targetMove != _transform.position)
      {
         _transform.position = Vector3.MoveTowards(_transform.position, _targetMove, _moveSpeed * Time.deltaTime);
         _playerAnimation.TransferIsRun(true);
      }
      else
      {
         _playerAnimation.TransferIsRun(false);
      }
   }

   private float Magnitude()
   {
      int normalizedValue = 100;
      Vector3 currentPosition = _transform.position;
      Vector3 diff = _oldPosition - currentPosition;
   
      _oldPosition = _transform.position;
      
      return diff.sqrMagnitude * normalizedValue;
   }
}
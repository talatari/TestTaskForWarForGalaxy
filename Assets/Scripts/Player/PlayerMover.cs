using UnityEngine;

public class PlayerMover : MonoBehaviour
{
   [SerializeField, Range(1, 10)] private float _moveSpeed = 2f;

   private GameObject _selectedGameObject;
   private Camera _camera;
   private Vector3 _targetMove;

   private void Awake() => _camera = Camera.main;

   private void Update()
   {
      InputPlayer();

      MoveToTarget();
   }

   private void InputPlayer()
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
      if (_targetMove != Vector3.zero)
      {
         transform.position = Vector3.MoveTowards(transform.position, _targetMove, _moveSpeed * Time.deltaTime);
         transform.rotation = Quaternion.LookRotation(_targetMove);
      }
   }
}
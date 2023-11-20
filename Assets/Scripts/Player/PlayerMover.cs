using System;
using UnityEngine;

[RequireComponent(
   typeof(PlayerAnimation),
   typeof(Rigidbody))]

public class PlayerMover : MonoBehaviour
{
   [SerializeField, Range(0, 10)] private float _moveSpeed = 0.2f;

   private Camera _camera;
   private Vector3 _targetMove;
   private PlayerAnimation _playerAnimation;
   private Rigidbody _rigidbody;

   private void Awake()
   {
      _camera = Camera.main;
      _playerAnimation = GetComponent<PlayerAnimation>();
      _rigidbody = GetComponent<Rigidbody>();
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
      if (_targetMove != _rigidbody.transform.position)
      {
         _rigidbody.velocity = _targetMove * _moveSpeed;
         _rigidbody.transform.rotation = Quaternion.LookRotation(_targetMove);
         
         if (_rigidbody.velocity.magnitude > 0)
            _playerAnimation.TransferSpeed(_rigidbody.velocity.magnitude);
      }
   }
}
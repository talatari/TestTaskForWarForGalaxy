using UnityEngine;

[RequireComponent(
   typeof(PlayerAnimation),
   typeof(Rigidbody))]

public class PlayerMoverRigidbody : MonoBehaviour
{
   [SerializeField] private float _moveSpeed = 10f;
   [SerializeField] private float _rotateSpeed = 10f;
      
   private PlayerAnimation _playerAnimation;
   private Rigidbody _rigidbody;

   private void Start()
   {
      _playerAnimation = GetComponent<PlayerAnimation>();
      _rigidbody = GetComponent<Rigidbody>();
   }

   public void MoveToDestination(Vector3 moveDirection)
   {
      Vector3 offset = moveDirection * (_moveSpeed * Time.deltaTime);
      _rigidbody.MovePosition(_rigidbody.position + offset);
   }

   public void RotateToDestination(Vector3 moveDirection)
   {
      if (Vector3.Angle(transform.forward, moveDirection) > 0)
      {
         Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
         transform.rotation = Quaternion.LookRotation(newDirection);
      }
   }
}
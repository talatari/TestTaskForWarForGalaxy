using UnityEngine;

[RequireComponent(
    typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake() => _animator = GetComponent<Animator>();

    public void TransferSpeed(float playerSpeed)
    {
        _animator.SetFloat("PlayerSpeed", playerSpeed);
        print(playerSpeed);
    }
}
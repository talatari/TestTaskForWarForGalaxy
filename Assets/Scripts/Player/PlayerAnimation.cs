using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private const string IsRun = "IsRun";
    
    private Animator _animator;
    
    private void Start() => _animator = GetComponent<Animator>();

    public void TransferIsRun(bool isRun) => _animator.SetBool(IsRun, isRun);
}
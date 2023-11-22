using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Run = Animator.StringToHash("IsRun");
    
    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    public void OnAnimationRun(bool isRun) => _animator.SetBool(Run, isRun);
}
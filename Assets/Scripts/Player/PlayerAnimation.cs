using System;
using UnityEngine;

[RequireComponent(
    typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void TransferSpeed(float playerSpeed)
    {
        if (Math.Abs(playerSpeed) > 0)
            _animator.SetFloat("PlayerSpeed", playerSpeed);
    }
}
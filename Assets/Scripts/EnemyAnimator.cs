using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int Follow = Animator.StringToHash("Follow");
    public static readonly int Walk = Animator.StringToHash("IsWalking");
    public static readonly int Run = Animator.StringToHash("IsRunning");
    [SerializeField] private AIPath _aIPath;

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void PlayFollow()
    {
        _animator.SetTrigger(Follow);
    }

    public void IsWalking(bool condition)
    {
        _animator.SetBool(Walk, condition);
    }

    public void IsRunning(bool condition)
    {
        _animator.SetBool(Run, condition);
    }

    public void OnEnableCanMove()
    {
        _aIPath.canMove = true;
    }

    public void OnDisableCanMove()
    {
        _aIPath.canMove = false;
    }
}

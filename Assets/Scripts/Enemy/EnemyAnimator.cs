using System;
using UnityEngine;

namespace Enemy
{
  public class EnemyAnimator : MonoBehaviour, IAnimationStateReader
  {
    private readonly int _idleStateHash = Animator.StringToHash("Idle");
    private readonly int _attackStateHash = Animator.StringToHash("Attack01");
    private readonly int _walkingStateHash = Animator.StringToHash("Run");
    private readonly int _deathStateHash = Animator.StringToHash("Death");
    private readonly int _hitStateHash = Animator.StringToHash("GetHit");
    private readonly int _victoryStateHash = Animator.StringToHash("Victory");

   [SerializeField] private Animator _animator;

    public event Action<AnimatorState> StateEntered;
    public event Action<AnimatorState> StateExited;

    public AnimatorState State { get; private set; }

   

    public void PlayHit()
    {
      _animator.CrossFade(_hitStateHash,0.3f);
    }

    public void PlayDeath()
    {
      _animator.CrossFade(_deathStateHash,0.3f);
    }

    public void Win()
    {
      _animator.CrossFade(_victoryStateHash,0.3f);
    }

    public void Move()
    {
     // _animator.CrossFade(_walkingStateHash,0.3f);
      _animator.Play(_walkingStateHash);
    }

    public void Stand()
    {
      _animator.CrossFade(_idleStateHash,0.3f);
    }


    public void PlayAttack()
    {
    
      //_animator.CrossFade(_attackStateHash,0.3f);
      _animator.Play(_attackStateHash);
    }

    public void EnteredState(int stateHash)
    {
      /*State = StateFor(stateHash);
      StateEntered?.Invoke(State);*/
    }
    
    public void ExitedState(int stateHash)
    {
      /*StateExited?.Invoke(StateFor(stateHash));*/
    }

    private AnimatorState StateFor(int stateHash)
    {
      AnimatorState state;
      if (stateHash == _idleStateHash)
        state = AnimatorState.Idle;
      else if (stateHash == _attackStateHash)
        state = AnimatorState.Attack;
      else if (stateHash == _walkingStateHash)
        state = AnimatorState.Walking;
      else if (stateHash == _deathStateHash)
        state = AnimatorState.Died;
      else
        state = AnimatorState.Unknown;
      
      return state;
    }
  }
}
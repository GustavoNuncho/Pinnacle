using System;
using UnityEngine;


public class AttackState : BaseState
{
    private ShortRangeEnemy _ShortRangeEnemy;
    private Vector3 playerPosition;

    private float direction;
    public AttackState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }

    public override Type Tick()
    {
        _ShortRangeEnemy.myAnimator.SetBool("Chase", false);
        _ShortRangeEnemy.myAnimator.SetBool("Attack", true);

        Debug.Log("Attack State");
        
        direction = 0;
        _ShortRangeEnemy.EnemyMove(direction);
        _ShortRangeEnemy.Attacking = false;
        return typeof(WanderState);
        
    }
}
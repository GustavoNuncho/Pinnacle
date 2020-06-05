using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DieState : BaseState
{

    public ShortRangeEnemy _ShortRangeEnemy;

    public DieState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy = shortRangeEnemy;

    }    

    public override Type Tick()
    {
        if(_ShortRangeEnemy.dead == false){
            _ShortRangeEnemy.myAnimator.SetTrigger("Death");
            _ShortRangeEnemy.dead = true;
            _ShortRangeEnemy.enemy.Die();
            _ShortRangeEnemy.enabled = false;
        }
        else{
            Debug.Log("Already dead");
        }
        
        return typeof(DieState);

        
    }
    
}

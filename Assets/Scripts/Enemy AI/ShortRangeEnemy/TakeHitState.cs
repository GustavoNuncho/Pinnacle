using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TakeHitState : BaseState
{
    ShortRangeEnemy _ShortRangeEnemy;
   public TakeHitState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }

    public override Type Tick()
    {
        
        _ShortRangeEnemy.myAnimator.SetTrigger("TakeHit");
        return typeof(TakeHitState);

    }
}

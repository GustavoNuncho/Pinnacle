using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WanderState : BaseState
{
    private ShortRangeEnemy _enemy;

    

    public WanderState(ShortRangeEnemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
    }


   
    
    
    public override Type Tick(){
        return null;

    }
    


}
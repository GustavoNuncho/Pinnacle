using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;


public class ChaseState : BaseState
{
    private ShortRangeEnemy _ShortRangeEnemy;
    private Vector3 playerPosition;

    private float direction;
    public ChaseState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }

    public override Type Tick(){
        Debug.Log("ChaseState");
       


        playerPosition = _ShortRangeEnemy.playerManager.player.transform.position;

        if(playerPosition.x  < _ShortRangeEnemy.transform.position.x)
        {
            if(_ShortRangeEnemy.movingRight){
                _ShortRangeEnemy.movingRight = false;
                direction = -1.0f;
                
                _ShortRangeEnemy.EnemyMove(direction);
                _ShortRangeEnemy.currentDirection = -1;
                _ShortRangeEnemy.flip();
            }
            else
            {
                direction = -1.0f;
                
                _ShortRangeEnemy.EnemyMove(direction);
                _ShortRangeEnemy.currentDirection = -1;
                _ShortRangeEnemy.flip();
            }
        }
        else
        {
            if(!_ShortRangeEnemy.movingRight){
                    _ShortRangeEnemy.movingRight = true;
                    direction = 1.0f;
                    _ShortRangeEnemy.EnemyMove(direction);
                    _ShortRangeEnemy.currentDirection = 1;
                _ShortRangeEnemy.flip();
            }
            else
            {
                direction = 1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
                _ShortRangeEnemy.currentDirection = 1;
                _ShortRangeEnemy.flip();
            }
        }
         if(Vector3.Distance(transform.position,playerPosition) > _ShortRangeEnemy.hearRadius)
        {
            _ShortRangeEnemy.Chasing = false;
            return typeof(WanderState);
        }

        //Debug.Log("Made it to chase state");
        _ShortRangeEnemy.Chasing = false;
        return typeof(WanderState);
    }
}

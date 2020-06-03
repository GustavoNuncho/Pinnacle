using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class WanderState : BaseState
{
    

    private ShortRangeEnemy _ShortRangeEnemy;
    public float originOffset = 2.0f;
    private float raycastMaxDistance;

    private float direction;

    private Vector3 playerPosition;

    private float wanderingTime;
    

    public WanderState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }
    


        public override Type Tick()
        {
            _ShortRangeEnemy.myAnimator.SetBool("Chase", true);


            playerPosition = _ShortRangeEnemy.playerManager.player.transform.position;
            wanderingTime += Time.deltaTime;
          
            if(Vector3.Distance(transform.position,playerPosition) <= _ShortRangeEnemy.hearRadius)
            {
                return typeof(ChaseState);
            }
            _ShortRangeEnemy.wanderTimer -= Time.deltaTime;

            WanderCheck();

            if(_ShortRangeEnemy.movingRight){
                direction = 1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }
            else {
                direction = -1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }   

        
            if( Detection(direction).collider.tag  == "Ground" && _ShortRangeEnemy.movingRight == false)
            {
                _ShortRangeEnemy.movingRight = true;
                _ShortRangeEnemy.currentDirection = 1;
                _ShortRangeEnemy.flip();
            }
            else if(Detection(direction).collider.tag  == "Ground" && _ShortRangeEnemy.movingRight)
            {
                _ShortRangeEnemy.movingRight = false;
                _ShortRangeEnemy.currentDirection = -1;
                _ShortRangeEnemy.flip();
            }
           
            return typeof(WanderState); 

        }
        public void WanderCheck()
    { 
       if(_ShortRangeEnemy.wanderTimer  < 0.1f )
       {
           _ShortRangeEnemy.wanderTimer = 5.0f;
           if(_ShortRangeEnemy.movingRight = true)
           {
               _ShortRangeEnemy.movingRight = false;
               _ShortRangeEnemy.currentDirection = -1;
               _ShortRangeEnemy.flip();
               
           }
           else
           {
               _ShortRangeEnemy.movingRight = true;
               _ShortRangeEnemy.currentDirection = 1;
                _ShortRangeEnemy.flip();
           }
       }
    }

        private RaycastHit2D Detection(float direction)
        {
            float directionOriginOffset = originOffset * (direction > 0 ? 1 : -1);
            Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset,transform.position.y);
            
            Vector2 currentDirection = new Vector2(direction, 0);
            Debug.DrawRay(startingPosition, currentDirection, Color.black);
            return Physics2D.Raycast(startingPosition, currentDirection, raycastMaxDistance);  
        }

        
    }

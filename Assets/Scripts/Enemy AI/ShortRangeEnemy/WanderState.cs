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
            Debug.Log("WanderState");
            _ShortRangeEnemy.myAnimator.SetBool("Chase", true);
            _ShortRangeEnemy.myAnimator.SetBool("Attack", false);


            playerPosition = _ShortRangeEnemy.playerManager.player.transform.position;
            wanderingTime += Time.deltaTime;
          
            if(Vector3.Distance(transform.position,playerPosition) <= _ShortRangeEnemy.hearRadius && Vector3.Distance(transform.position,playerPosition) > _ShortRangeEnemy.lookRadius)
            {
                _ShortRangeEnemy.Chasing = true;    
               
            }
            if(_ShortRangeEnemy.Chasing == true)
            {
                return typeof(ChaseState);
            }

            
            if(Vector3.Distance(transform.position,playerPosition) < _ShortRangeEnemy.lookRadius)
            {
                //direction = 0.0f;
                _ShortRangeEnemy.Attacking = true;
            }

            if(_ShortRangeEnemy.Attacking == true)
            {
                return typeof(AttackState);
            }
            _ShortRangeEnemy.wanderTimer -= Time.deltaTime;

            WanderCheck();

            if(_ShortRangeEnemy.movingRight)
            {
                direction = 1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }
            else 
            {
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
           _ShortRangeEnemy.wanderTimer = UnityEngine.Random.Range(_ShortRangeEnemy.wanderMin, _ShortRangeEnemy.wanderMax);
           if(_ShortRangeEnemy.movingRight == true)
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
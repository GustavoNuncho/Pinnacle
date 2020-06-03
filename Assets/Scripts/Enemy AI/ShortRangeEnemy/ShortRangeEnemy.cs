using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;



public class ShortRangeEnemy : MonoBehaviour
{
    //Enviroment Detection

    public float hearRadius;
    public float lookRadius;
    public float playerAttackRadius;
    public float currentDirection;
    public BoxCollider2D boxCollider => GetComponent<BoxCollider2D>();
    public Rigidbody2D rigidbody2D => GetComponent<Rigidbody2D>();
    
    public bool movingRight;

    public Animator myAnimator => GetComponent<Animator>();
    //public Animator animator => GetComponent<Animator>();

    // Enemy Stats

    
    
    //Enemy Controller
    public float wanderTimer;
    public float wanderMin;
    public float wanderMax;
    public float speed;

    private Vector3 m_Velocity = Vector3.zero;
    
    public StateMachine  stateMachine =>  GetComponent<StateMachine>();
    public PlayerManager playerManager => GetComponent<PlayerManager>();
    public SpriteRenderer renderer => GetComponent<SpriteRenderer>();

    // Start is called before the first frame update
    void Awake()
    {
      InitializeStateMachine();
      currentDirection = 1f;
    
    }

    void Update()
    {
        
        
        
        
    }
    private void InitializeStateMachine(){
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WanderState), new WanderState(this)},
            {typeof(ChaseState), new ChaseState(this)}

        };
         stateMachine.SetState(states);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,  hearRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,  lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,  playerAttackRadius);  
    }

    public void EnemyMove(float direction){
        Debug.Log("Enemy Moving");
        Vector3 targetVelocity = new Vector2(direction * speed, rigidbody2D.velocity.y );
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity,ref m_Velocity , 0.3f );

    }

    public void flip()
    {
        if(currentDirection < 0.1f)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }
    }

    public void WanderCheck()
    { 
       //if(wanderTimer < 0.0f)
        Debug.Log("Hello");
    }

   public void DestroyEnemy()
   {
       Destroy(this.gameObject, 4.0f);
   }


}


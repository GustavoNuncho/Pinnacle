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
    public float currentDirection;
    public BoxCollider2D boxCollider => GetComponent<BoxCollider2D>();
    new public Rigidbody2D rigidbody => GetComponent<Rigidbody2D>();
    
    public bool movingRight;

    public bool Wandering;
    public bool Chasing;
    public bool Attacking;
    public bool dead;

    public Animator myAnimator => GetComponent<Animator>();
   public Enemy enemy => GetComponent<Enemy>();

    // Enemy Stats

    
    
    //Enemy Controller
    public float wanderTimer;
    public float wanderMin;
    public float wanderMax;
    public float speed;

    private Vector3 m_Velocity = Vector3.zero;

    public float takingHit;


    
    public float health; 
    
    public StateMachine  stateMachine =>  GetComponent<StateMachine>();
    public PlayerManager playerManager => GetComponent<PlayerManager>();
    new public SpriteRenderer renderer => GetComponent<SpriteRenderer>();

    // Start is called before the first frame update
    void Awake()
    {
      InitializeStateMachine();
      currentDirection = 1f;
    
    }

    void Update()
    {   


        if(health > enemy.currentHealth)
        {
            health = enemy.currentHealth;
            myAnimator.SetTrigger("TakeHit");
            DamageStateChange();
        }
        
        
        
        
    }
    private void InitializeStateMachine(){
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WanderState), new WanderState(this)},
            {typeof(ChaseState), new ChaseState(this)},
            {typeof(AttackState), new AttackState(this)},
            {typeof(TakeHitState), new TakeHitState(this)},
            {typeof(DieState), new DieState(this)}

        };
         stateMachine.SetState(states);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,  hearRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,  lookRadius);
    
    }

    public void EnemyMove(float direction){
        Debug.Log("Enemy Moving");
        Vector3 targetVelocity = new Vector2(direction * speed, rigidbody.velocity.y );
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity,ref m_Velocity , 0.3f );

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

   public void DestroyEnemy()
   {
       Destroy(this.gameObject, 4.0f);
   }



   public void TakeDamage()
   {
       //playerManager.player.
   }
    private void DamageStateChange()
   {
       var states = new Dictionary<Type, BaseState>()
       {
           {typeof(TakeHitState), new TakeHitState(this)},
           {typeof(DieState), new DieState(this)}
       };
       if(health <= 0){
           stateMachine.SwitchToNewState(states.Values.Last().Tick());
       }
       else{
           stateMachine.SwitchToNewState(states.Values.First().Tick());
       }
   }

}


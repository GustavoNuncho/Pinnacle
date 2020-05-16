using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class ShortRangeEnemy : MonoBehaviour
{

    public float lookRadius;

    public StateMachine  stateMachine =>  GetComponent<StateMachine>();

    // Start is called before the first frame update
    void Awake()
    {

    }



    private void InitializeStateMachine(){
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WanderState), new WanderState(this)}

        };
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,  lookRadius);
        
    }



   public void DestroyEnemy()
   {
       Destroy(this.gameObject, 4.0f);
   }


}


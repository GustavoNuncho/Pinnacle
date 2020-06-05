using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Text gameMsg;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            gameMsg.text = "You Win!";
        }
    }

    public void PlayerDied()
    {
        gameMsg.text = "You Lose!";
    }

    public void EnemyDied()
    {
        gameMsg.text = "You Win!";
    }
}

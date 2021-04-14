using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int eggContacts = 0;
    private GameController mGameController = null;
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log((other.tag).ToString());
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            mGameController.planeTouches += 1;
            mGameController.EnemyDestroyed();
        } else
        {
            eggContacts += 1;
            if(eggContacts >= 4)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                mGameController.EnemyDestroyed();
            } else
            {
                Destroy(other.gameObject);
                Color col = this.gameObject.GetComponent<Renderer>().material.color;
                col.a *= 0.8f;
                this.gameObject.GetComponent<Renderer>().material.color = col;
            }
        }
    }
}

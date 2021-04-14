using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUpBehaviour : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float maxSpeed = 60f;
    public float speed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; 
    public bool mFollowMousePosition = true;
    private float fireRate = 0.2f;
    private float nextShot = 0;
    private Rigidbody2D rb2d;
    private GameController mGameController = null;

    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;
            Debug.Log(mGameController.controlMode);
            if (mGameController.controlMode)
            {
                mGameController.controlMode = false;
            }
            else
            {
                mGameController.controlMode = true;
            }
        }
        Vector3 pos = this.transform.position;

        if (mFollowMousePosition)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                speed += 0.1f;
                //pos += ((speed * Time.smoothDeltaTime) * transform.up);
            }

            if (Input.GetKey(KeyCode.S))
            {
                speed -= 0.1f;
                //pos -= ((speed * Time.smoothDeltaTime) * transform.up);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            mGameController.eggCount += 1;
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); 
            e.transform.localPosition = transform.localPosition;
            e.transform.rotation = transform.rotation;
        }
        rb2d.velocity = transform.up * speed;
        transform.position = pos;
    }
}

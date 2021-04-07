using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode jumpKey;

    public float speed = 10f;

    void Update()
    {
        Vector3 pos = transform.position;

        // "w" can be replaced with any key
        // this section moves the character up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed * Time.deltaTime;
        }

        // "s" can be replaced with any key
        // this section moves the character down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed * Time.deltaTime;
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;
    }
}

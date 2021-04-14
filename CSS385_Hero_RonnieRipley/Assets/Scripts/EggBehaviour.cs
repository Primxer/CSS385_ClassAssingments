using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour
{
    public const float kEggSpeed = 40f;
    private GameController mGameController = null;

    // Start is called before the first frame update
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
    }

    void OnBecameInvisible()
    {
        mGameController.eggCount -= 1;
        Destroy(gameObject);
    }
}

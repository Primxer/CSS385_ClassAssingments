using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int maxPlanes = 10;
    private int numberOfPlanes = 0;
    public int eggCount;
    public int planeTouches;
    public int destroyedCount;
    public bool controlMode;
    public Text gameUIText = null;

    // Start is called before the first frame update
    void Start()
    {
        controlMode = true;
        gameUIText.text = "Control Mode: Mouse" + " Egg Count = " + eggCount + " Enemy Count = " 
            + numberOfPlanes + " Planes Touched = " + planeTouches + "Planes Destroyed: " + destroyedCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlMode)
        {
            gameUIText.text = "Control Mode: Mouse" + " Egg Count = " + eggCount + " Enemy Count = " 
                + numberOfPlanes + " Planes Touched = " + planeTouches + " Planes Destroyed: " + destroyedCount;        
        } else
        {
            gameUIText.text = "Control Mode: Mouse" + " Egg Count = " + eggCount + " Enemy Count = "
                            + numberOfPlanes + " Planes Touched = " + planeTouches + " Planes Destroyed: " + destroyedCount;
        }

        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if (numberOfPlanes < maxPlanes)
        {
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            Vector3 pos;
            pos.x = (s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x) * 0.9f;
            pos.y = (s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y) * 0.9f;
            pos.z = 0;
            e.transform.localPosition = pos;
            ++numberOfPlanes;
        }
    }

    public void EnemyDestroyed() {
        ++destroyedCount;
        --numberOfPlanes;
    } 
}

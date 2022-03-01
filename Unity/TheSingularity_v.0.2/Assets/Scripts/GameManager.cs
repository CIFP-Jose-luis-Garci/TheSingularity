using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gamePaused;
    public static float volume;
    public static bool alive;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        alive = true;
    }

}

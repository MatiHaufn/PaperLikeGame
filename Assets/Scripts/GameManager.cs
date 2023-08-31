using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public GameObject Player;

    public bool pauseActive = false; 



    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }


    public void PauseGame(bool pause)
    {
        pauseActive = pause; 
    }
}

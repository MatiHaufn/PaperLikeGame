using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class SchiebeboxScript : MonoBehaviour
{
    GameObject Player;

    public float movingStep = 1; 

    bool timerActivated = false; 
    float schiebeTimer = 0;
    float maxSchiebeTimer = 1;
    float offsetTime = 0.2f; 


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
    }
    void Update()
    {
        if (timerActivated)
        {
            if(schiebeTimer <= maxSchiebeTimer)
            {
                if (Player.GetComponent<PlayerMovement>()._moving)
                {
                    schiebeTimer += Time.deltaTime;
                    if (schiebeTimer >= maxSchiebeTimer - offsetTime)
                    {
                        AnimationMoveForward();
                        schiebeTimer = 0;
                    }
                }
                else
                    schiebeTimer = 0; 
            }
        }
    }

    void AnimationMoveForward()
    {
        Vector2 startPoint = Player.transform.position;
        Vector2 endPoint = this.transform.position;

        Vector2 direction = (endPoint - startPoint).normalized;
        
        transform.position += new Vector3(direction.x + movingStep, 0, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timerActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timerActivated = false;
            schiebeTimer = 0; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    Animator animator;
    Vector3 playerSpeed;
    bool isRunning; 
    float leftRotation = 0;
    float rightRotation = 180;
    bool isFlipping = false;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        if (!GameManager.Instance.pauseActive)
        {
            playerSpeed = GameManager.Instance.Player.GetComponent<PlayerMovement>().move;

            if (playerSpeed.x != 0 || playerSpeed.z != 0)
                isRunning = true;
            else
                isRunning = false;

            animator.SetBool("isRunning", isRunning);

            if (!isFlipping)
            {
                if (playerSpeed.x < 0)
                {
                    isFlipping = true; 
                    StartCoroutine(TurnSprite(rightRotation, leftRotation));
                }
                else if(playerSpeed.x > 0)
                {
                    isFlipping = true;
                    StartCoroutine(TurnSprite(leftRotation, rightRotation));
                }
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        Debug.Log(isFlipping);
    }

    //STEHENE GEBLIEBEN
    IEnumerator TurnSprite(float start, float end)
    {
        float currentYValue = start;
        float offset = 2; 

        if(isFlipping)
        {
            if(start < end)
            {
                Debug.Log("schaut rechts: " + transform.eulerAngles.y);
                if(transform.eulerAngles.y >= end - offset)
                {
                    yield return null; 
                }
            }
            else if(start > end)
            {
                Debug.Log("schaut links: " + transform.eulerAngles.y);
                if (transform.eulerAngles.y <= end + offset)
                {
                    yield return null;
                }
            }
        }
    
        isFlipping = false; 
        
        for (float time = 0; time <= 1; time += 0.01f)
        {
            currentYValue = Mathf.Lerp(start, end, time);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentYValue, transform.eulerAngles.z);

            yield return new WaitForSeconds(0.001f);
        }
//        isFlipping = false; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogTrigger : MonoBehaviour
{
    //Dialogue with NPC
    GameObject lastTouchedNPC;
    bool inRange = false;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Interact") == 1 && lastTouchedNPC != null && inRange)
        {
            lastTouchedNPC.gameObject.GetComponent<NPC>().StartSpeaking();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            other.gameObject.GetComponent<NPC>().ActivateBubbleAnimation();

            lastTouchedNPC = other.gameObject;
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            other.gameObject.GetComponent<NPC>().DeactivateBubbleAnimation();
            inRange = false;
        }
    }
}

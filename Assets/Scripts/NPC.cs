using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public GameObject SmallSpeechbubble;
    bool playerInRange = false;
    public DialogueRunner dialogueRunner;
   
    public void ActivateBubbleAnimation()
    {
        playerInRange = true;
        SmallSpeechbubble.GetComponent<Animator>().SetBool("SpeechbubbleActive", true);
    }
    public void DeactivateBubbleAnimation()
    {
        playerInRange = false;
        SmallSpeechbubble.GetComponent<Animator>().SetBool("SpeechbubbleActive", false);
    }

    public void StartSpeaking()
    {
        dialogueRunner.StartDialogue("NPC1");
    }
 }

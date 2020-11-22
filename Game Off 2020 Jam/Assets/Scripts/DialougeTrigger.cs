using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge;
    public GameObject DialougeBox;
    public GameObject Button;
    public bool inConversation = false;
    public void triggerDialouge() 
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
        DialougeBox.SetActive(true);
        Button.SetActive(false);
        inConversation = true;
    } 
}

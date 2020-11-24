using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI dialougeText;
    public TextMeshProUGUI nameText;
    public GameObject ExitButton;
    public GameObject dialougebox;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialouge(Dialouge dialouge) 
    {
        nameText.text = dialouge.npcName;
        // Clear any sentences from the conversation before
        sentences.Clear();
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentences();    
    }
    public void DisplayNextSentences()
    {
        if(sentences.Count == 0)
        {
            ExitButton.SetActive(true);
            return;
        }
        string sentence = sentences.Dequeue();

        dialougeText.text = sentence;
    }
    public void EndDialouge()
    {
        dialougebox.SetActive(false);
        ExitButton.SetActive(false);

    }
}

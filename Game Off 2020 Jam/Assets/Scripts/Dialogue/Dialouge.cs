using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{
    public string npcName;

    [TextArea(2,6)]
    public string[] sentences;
}

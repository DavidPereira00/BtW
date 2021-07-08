using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public GameObject DialogueBox;
	public Player Player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CloseDialogue() 
    {
        DialogueBox.SetActive(false);
        Player.canMovee = true;
    }
}

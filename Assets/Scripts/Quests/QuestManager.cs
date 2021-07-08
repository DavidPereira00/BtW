using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] questCompleted;
	public DialogueManager theDm;
	public string itemCollected;
	public int talked;

	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Length];
		talked = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	public void ShowQuestText(string questText){
		theDm.dialogLines = new string[1];
		theDm.dialogLines [0] = questText;

		theDm.currentLine = 0;
		theDm.ShowDialogue ();
	}
}

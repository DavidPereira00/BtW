using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public int questNumber;
	public string dialogue;
	private DialogueManager dMAn;
	private QuestManager theQM;
	private NPC theNPC;
	public bool startQuest;
	public bool endQuest;
	public GameObject dzone;
	public GameObject popup;
	public Player player;
	public bool talked = false;

	public bool bulletOf = false;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType <DialogueManager>();
		theQM = FindObjectOfType <QuestManager>();
		theNPC = FindObjectOfType<NPC>();
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (dMAn.currentLine >= dMAn.dialogLines.Length) {
			InitiateQuest ();
		}*/
		if (Input.GetKeyUp(KeyCode.Z)&& bulletOf==true)
		{
			//dMAn.ShowBox (dialogue);
			bulletOf = true;
			if (!dMAn.dialogActive)
			{
				dMAn.dialogLines = dialogueLines;
				dMAn.currentLine = 0;
				//InitiateQuest ();
				popup.SetActive(true);

				dMAn.ShowDialogue();
				//talked = true;

				//gameObject.SetActive(false);
				//dzone.SetActive(true);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			
				bulletOf = true;
								
			
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player")
		{

			bulletOf = false;


		}
	}

	public void InitiateQuest(){
		if (!theQM.questCompleted [questNumber]) 
		{
			if (startQuest && !theQM.quests [questNumber].gameObject.activeSelf) 
			{
				theQM.quests [questNumber].gameObject.SetActive (true);
				gameObject.SetActive(false);
				dzone.SetActive(true);
				popup.SetActive(false);
				dMAn.closeDialogue();
				talked = true;
				
				//EHM.enemyQuestName = "Enemy";
				//theQM.quests [questNumber].StartQuest ();
				//theNPC.queststarted = true;
			}
		}
	}
	public void CancelQuest()
    {
		Time.timeScale = 1;
		dMAn.closeDialogue();
		popup.SetActive(false);
		talked = false; ;
	}
}

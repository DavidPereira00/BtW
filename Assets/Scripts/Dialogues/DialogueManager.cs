using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;


	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	public string[] dialogLines2;
	public int currentLine2;

	private DialogueHolder DH;
	private Player thePlayer;
	private QuestManager theQM;
	private NPC theNPC;
	//public int questNumber;
	public bool startQuest;
	public bool endQuest;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Player>();
		theQM = FindObjectOfType<QuestManager>();
		theNPC = FindObjectOfType<NPC>();
		DH = FindObjectOfType<DialogueHolder> ();
	}

	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyUp(KeyCode.Z))//deactivation of the box message and dialogue
		{
			//dBox.SetActive (false);
			//dialogActive = false;

			currentLine++;
			currentLine2++;
		}

		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;
			thePlayer.canMovee = true;
			//DH.popup.SetActive(true);
		}
        
	
		
		dText.text = dialogLines [currentLine];
	}
	
	public void ShowDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
		thePlayer.canMovee = false;

	}
	public void closeDialogue()
	{
		dialogActive = false;
		dBox.SetActive(false);
		thePlayer.canMovee = true;

	}
}


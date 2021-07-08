using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {
	//public int questNumber;
	private QuestManager theQM;
	public string itemName;
	private ItemUI item;
	
	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
		item = GetComponent<ItemUI>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
				theQM.itemCollected = itemName;
				//gameObject.SetActive (false);
		}
	}
}

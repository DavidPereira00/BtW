using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestObject : MonoBehaviour
{
	public string questname;

	public int questNumber;
	public QuestManager TheQM;
	public DialogueManager TheDM;
	private DialogueManager dMAn;
	public DialogueHolder3 d3;
	//private NPC TheN;
	public string startText;
	public string endText;
	public bool isItemQuest;
	public bool isItemQuest2;
	public bool isItemQuest3;
	public string ti;
	public string ti2;
	public string ti3;

	public ItemType targetitem;
	public ItemType targetitem2;
	public ItemType targetitem3;

	public GameObject npc;
	public GameObject dzone;
	public GameObject zoned;
	private Inventory inventory;
	public GameObject inventoryPanel;
	public GameObject questys;
	public GameObject questysamount;
	public GameObject questystimer;
	public float timer;
	public int seconds;
	public int targetamount;
	public int targetamount2;
	public int targetamount3;
	public bool questfinished = false;
	public int currentamount;
	public int currentamount2;
	public int currentamount3;

	public Player player;
	public InventoryUI iui;

	public bool h1 = false;
	public bool h2 = false;
	public bool h3 = false;


	// Use this for initialization
	void Awake()
	{


	}

	void Start()
	{
		TheDM = FindObjectOfType<DialogueManager>();
		questys.SetActive(true);
	}

	// Update is called once per frame
	void Update()
	{
		questys.SetActive(true);
		timer -= Time.deltaTime;
		seconds = (int)timer;

		if (isItemQuest)
		{
			questysamount.GetComponent<UnityEngine.UI.Text>().text = ("#" + questNumber + ": " + ti + " (" + currentamount.ToString() + "/" + targetamount.ToString() + ") • " + seconds.ToString() + " SECONDS LEFT...").ToUpper();
			questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;

			List<Item> currentItems = player.GetInventory().items;
			for (int i = 0; i < currentItems.Count; i++)
			{
				currentamount = 0;
				if (currentItems.ElementAt(i).itemType == targetitem && d3.talked == false)
				{
					currentamount = currentItems.ElementAt(i).amount;
				}

				if (currentItems.ElementAt(i).itemType == targetitem && currentItems.ElementAt(i).amount >= targetamount)
				{
					TheQM.itemCollected = null;

					FinishQuest();

					dzone.SetActive(false);
					zoned.SetActive(true);

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems.ElementAt(i));

						}
						//currentamount = currentamount - targetamount;
						iui.RefreshItems();
					}

					break;
				}

			}
		}

		if (isItemQuest2)
		{
			questysamount.GetComponent<UnityEngine.UI.Text>().text = ("#" + questNumber + ": " + ti + " (" + currentamount.ToString() + "/" + targetamount.ToString() + ") & " + ti2 + " (" + currentamount2.ToString() + "/" + targetamount2.ToString() + ") | " + seconds.ToString() + " SECONDS").ToUpper();
			questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;

			List<Item> currentItems = player.GetInventory().items;
			for (int i = 0; i < currentItems.Count; i++)
			{
				currentamount = 0;
				if (currentItems.ElementAt(i).itemType == targetitem && d3.talked == false)
				{
					currentamount = currentItems.ElementAt(i).amount;
				}

				if (currentItems.ElementAt(i).itemType == targetitem && currentItems.ElementAt(i).amount >= targetamount)
				{
					h1 = true;
					if (h1 == true && h2 == true)
					{

						TheQM.itemCollected = null;

						FinishQuest();

						dzone.SetActive(false);
						zoned.SetActive(true);
					}

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems.ElementAt(i));

						}
						//currentamount = currentamount - targetamount;
						iui.RefreshItems();
					}

					break;
				}

			}

			List<Item> currentItems2 = player.GetInventory().items;
			for (int i = 0; i < currentItems2.Count; i++)
			{
				currentamount2 = 0;
				if (currentItems2.ElementAt(i).itemType == targetitem2 && d3.talked == false)
				{
					currentamount2 = currentItems2.ElementAt(i).amount;
				}

				if (currentItems2.ElementAt(i).itemType == targetitem2 && currentItems2.ElementAt(i).amount >= targetamount2)
				{
					h2 = true;
					if (h1 == true && h2 == true)
					{
						TheQM.itemCollected = null;

						FinishQuest();

						dzone.SetActive(false);
						zoned.SetActive(true);
					}

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount2; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems2.ElementAt(i));

						}
						//currentamount2 = currentamount2 - targetamount2;
						iui.RefreshItems();
					}

					break;
				}

			}
		}

		if (isItemQuest3)
		{
			questysamount.GetComponent<UnityEngine.UI.Text>().text = ("#" + questNumber + ": " + ti + " (" + currentamount.ToString() + "/" + targetamount.ToString() + ") & " + ti2 + " (" + currentamount2.ToString() + "/" + targetamount2.ToString() + ") & " + ti3 + " (" + currentamount3.ToString() + "/" + targetamount3.ToString() + ") | " + seconds.ToString() + " SECONDS").ToUpper();
			questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;

			List<Item> currentItems = player.GetInventory().items;
			for (int i = 0; i < currentItems.Count; i++)
			{
				if (currentItems.ElementAt(i).itemType == targetitem && d3.talked == false)
				{
					currentamount = currentItems.ElementAt(i).amount;
				}

				if (currentItems.ElementAt(i).itemType == targetitem && currentItems.ElementAt(i).amount >= targetamount)
				{
					h1 = true;

					if (h1 == true && h2 == true && h3 == true)
					{
						TheQM.itemCollected = null;

						FinishQuest();

						dzone.SetActive(false);
						zoned.SetActive(true);
					}

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems.ElementAt(i));
						}
						currentamount = currentamount - targetamount;

						iui.RefreshItems();
					}

					break;
				}

			}

			List<Item> currentItems2 = player.GetInventory().items;
			for (int i = 0; i < currentItems2.Count; i++)
			{
				if (currentItems2.ElementAt(i).itemType == targetitem2 && d3.talked == false)
				{
					currentamount2 = currentItems2.ElementAt(i).amount;
				}

				if (currentItems2.ElementAt(i).itemType == targetitem2 && currentItems2.ElementAt(i).amount >= targetamount2)
				{
					h2 = true;

					if (h1 == true && h2 == true && h3 == true)
					{
						TheQM.itemCollected = null;

						FinishQuest();

						dzone.SetActive(false);
						zoned.SetActive(true);
					}

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount2; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems2.ElementAt(i));

						}

						iui.RefreshItems();
					}

					break;
				}

			}

			List<Item> currentItems3 = player.GetInventory().items;
			for (int i = 0; i < currentItems3.Count; i++)
			{
				if (currentItems3.ElementAt(i).itemType == targetitem3 && d3.talked == false)
				{
					currentamount3 = currentItems3.ElementAt(i).amount;
				}

				if (currentItems3.ElementAt(i).itemType == targetitem3 && currentItems3.ElementAt(i).amount >= targetamount3)
				{
					h3 = true;

					if (h1 == true && h2 == true && h3 == true)
					{
						TheQM.itemCollected = null;

						FinishQuest();

						dzone.SetActive(false);
						zoned.SetActive(true);
					}

					if (d3.talked == true)
					{
						questfinished = true;
						questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;

						for (int l = 0; l < targetamount3; l++)
						{
							player.GetInventory().RemoveItemFromInventory(currentItems3.ElementAt(i));
							currentamount3 = currentItems3.ElementAt(i).amount;
						}

						iui.RefreshItems();
					}

					break;
				}

			}
		}

		if (questfinished == true)
		{
			questysamount.GetComponent<UnityEngine.UI.Text>().text = "#" + questNumber + ": COMPLETED!";
			questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.green;
			TheQM.questCompleted[questNumber] = true;
			gameObject.SetActive(false);
			d3.gameObject.SetActive(false);

		}

		if (timer <= 0)
		{
			questysamount.GetComponent<UnityEngine.UI.Text>().text = "#" + questNumber + ": FAILED!";
			questysamount.GetComponent<UnityEngine.UI.Text>().color = Color.red;
			player.questsFailed++;
			gameObject.SetActive(false);
			d3.gameObject.SetActive(false);
			npc.SetActive(false);
		}
	}

	public void StartQuest()
	{

	}

	public void FinishQuest()
	{

	}

	public void EndQuest()
	{

		//TheQM.questCompleted [questNumber] = true;
		//gameObject.SetActive (false);
	}
}
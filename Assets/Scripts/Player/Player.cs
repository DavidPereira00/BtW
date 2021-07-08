using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    // MOVEMENT
    public float movementSpeed = 10;
    public float jumpForce;
    public UnityEvent onLand = new UnityEvent();

    public float movement = 0;
	
	float maxYVel = 0;
    public bool jump = false;

    // UI OBJECTS
    private Rigidbody2D rb;
    public GameObject inventoryPanel;
    public GameObject questsPanel;
    [SerializeField] private InventoryUI inventoryUI;

    // INVENTORY
    private Inventory inventory;
	public Squad_member[] squad_members;
	
	public Item soloMedkit;
    public Item squadMedkit;
    public int healOfKit = 25;

    private bool hasFirstUpgrade = false;
    private bool hasSecondUpgrade = false;
    private bool hasThirdUpgrade = false;
    private bool hasFourthUpgrade = false;

    //quests dialogue
    public bool canMovee;
    public int questsCompleted;
    private bool inDialogueZone;

    public int questsFailed;

    private ItemUI item;
    private Item itemt;
    public Slider questprogress;

    //animation
    public Animator animator;
    public bool facingLeft = false;

    // health bar
    public Slider hp;
    public HealthBar health;
    public int maxHealth = 100;
    public int currentHealth;
    public int speed;
    public float speedmultiplier;

    private TextMeshProUGUI messageLog;
    private TextMeshProUGUI gameOverMessage;

    public GameObject GameOverPanel;
    
    void Awake()
    {
        inventory = new Inventory(this);
        inventoryUI.SetInventory(inventory);
        GameObject messageLogObject = GameObject.Find("Canvas/MessageLog");
        messageLog = messageLogObject.GetComponent<TextMeshProUGUI>();
        GameObject gameOverObject = GameObject.Find("Canvas/Game Over/Game Over Text");
        gameOverMessage = gameOverObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        GameOverPanel.SetActive(false);

        // Set player's health
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);

        rb = GetComponent<Rigidbody2D>();
        item = GetComponent<ItemUI>();
    }

    void Update()
    {
        // GAME OVER (FAILURE)
        if (questsFailed == 3)
        {
            gameOverMessage.text = "GAME OVER\nYOU FAILED YOUR MISSION!";
            GameOverPanel.SetActive(true);
            return;
        }

        // GAME OVER (SUCCESS)
        if (questsCompleted == 9)
        {
            gameOverMessage.text = "GAME OVER\nMISSION SUCCESSFUL!";
            GameOverPanel.SetActive(true);
            return;
        }

        // GAME OVER (FAILURE)
        if (currentHealth <= 0)
        {
            gameOverMessage.text = "GAME OVER\nYOU WERE KILLED!";
            GameOverPanel.SetActive(true);
            return;
        }

        questprogress.value = questsCompleted;

        // upgrades
        if (!hasFirstUpgrade && questsCompleted == 2)
        {
            speedmultiplier = 1.2f;
            PrintMessage("TWO QUESTS COMPLETED. PLAYER SPEED INCREASED!");
            hasFirstUpgrade = true;
        }

        if (!hasSecondUpgrade && questsCompleted == 4)
        {
            jumpForce = 16;
            PrintMessage("FOUR QUESTS COMPLETED. PLAYER JUMP IMPROVED!");
            hasSecondUpgrade = true;
        }

        if (!hasThirdUpgrade && questsCompleted == 6)
        {
            hp.maxValue = 150;
            maxHealth = 150;
            health.SetHealth(currentHealth);
            PrintMessage("SIX QUESTS COMPLETED. MAXIMUM HEALTH INCREASED!");
            hasThirdUpgrade = true;
        }

        if (!canMovee)
        {
            movementSpeed = 0;
            return;
        }

        if (canMovee)
        {
            movementSpeed = speed *speedmultiplier;
        }

        movement = Input.GetAxis("Horizontal");

        if (movement == 0)
        {
            // Idle animation
            animator.SetBool("isRunning", false);
        }

        if(movement < 0 && !facingLeft)
        {
            // Run animation
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-(float)0.2, (float)0.2, 1);
            facingLeft = true;
        }

        if (movement > 0 && facingLeft)
        {
            // Run animation
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3((float)0.2, (float)0.2, 1);
            facingLeft = false;
        }
		
		if(rb.velocity.y == 0 && !jump)
        {
            if(movement != 0)
            {
                animator.SetBool("isRunning", true);
            }

            if (maxYVel < -20)
            {

                TakeDamage(10);
            }
            maxYVel = 0;

        }

        if(rb.velocity.y < 0 && !jump)
        {
            if(rb.velocity.y < maxYVel)
            {
                maxYVel = rb.velocity.y;
            }
        }

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed*speedmultiplier;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) {
			jump = true;
            maxYVel = 0;
			
            // Jump Animation
            animator.SetBool("isJumping", true);

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        } 
		
		if(jump && rb.velocity.y == 0)
        {
            jump = false;
            animator.SetFloat("speed", 4);

            if (maxYVel < -20)
            {
                TakeDamage(10);
            }

            animator.SetBool("isJumping", false);
        } else if (jump)
        {
            if (rb.velocity.y < maxYVel)
            {
                maxYVel = rb.velocity.y;
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && !PauseMenu.isPaused) {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            questsPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !PauseMenu.isPaused) {
            questsPanel.SetActive(!questsPanel.activeSelf);
            inventoryPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.H) && !PauseMenu.isPaused) {
			useHealthPackOnPlayer();
        }

        if (Input.GetKeyDown(KeyCode.J) && !PauseMenu.isPaused) {
			useHealthPackOnSquadron();
        }
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ItemUI itemUI = collider.GetComponent<ItemUI>();
        if (itemUI != null)
        {            
            inventory.AddItemToInventory(itemUI.GetItem());
            itemUI.DestroyItem();
        }
        
        if (collider.CompareTag("DialogZone"))
        {
            inDialogueZone = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("DialogZone"))
            inDialogueZone = false;
      
    }

    // Takes damage from enemy bullets
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health.SetHealth(currentHealth);
    }

    public void PrintMessage(String message) {
        StartCoroutine(ShowMessage(message));
    }

    IEnumerator ShowMessage(String message) {
        messageLog.text = message;
        messageLog.enabled = true;
        yield return new WaitForSeconds(4);
        messageLog.enabled = false;
    }
	
	void useHealthPackOnPlayer()
    {
		List<Item> currentItems = inventory.items;
		for (int i = 0; i < currentItems.Count; i++)
		{
			if (currentItems.ElementAt(i).itemType == ItemType.PlayerHealthPack)
			{
				if(currentHealth < 100)
				{
					if (currentHealth + healOfKit > 100)
					{
						currentHealth = 100;
					}
					else
					{
						currentHealth = currentHealth + healOfKit;
					}
				}

				health.SetHealth(currentHealth);
                inventory.RemoveItemFromInventory(currentItems.ElementAt(i));

                PrintMessage("YOU SUCCESSFULLY HEALED YOURSELF!");

                break;
			}
		}
    }

    void useHealthPackOnSquadron()
    {
        List<Item> currentItems = inventory.items;
        for (int i = 0; i < currentItems.Count; i++)
        {
            if (currentItems.ElementAt(i).itemType == ItemType.SquadronHealthPack)
            {
                for (int j = 0; j < squad_members.Length; j++)
                {
                    if (squad_members[j] != null)
                    {
                        if (squad_members[j].currentHealth < 100)
                        {
                            if (squad_members[j].currentHealth + healOfKit > 100)
                            {
                                squad_members[j].currentHealth = 100;
                            }
                            else
                            {
                                squad_members[j].currentHealth = squad_members[j].currentHealth + healOfKit;
                            }
                            
                            squad_members[j].health.SetHealth(currentHealth);
                        }
                    }
                }

                inventory.RemoveItemFromInventory(currentItems.ElementAt(i));

                PrintMessage("YOU SUCCESSFULLY HEALED YOUR SQUAD MEMBERS!");

                break;
            }
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
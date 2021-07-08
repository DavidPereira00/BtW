using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad_member : MonoBehaviour
{
    // MOVEMENT
    public float movementSpeed = 4;
    private Rigidbody2D rigidbody2D;
    int movement = 1;

    // array of enemy NPC's
    public GameObject[] enemy_npc;
    // closest enemy
    int current = 0;

    // prefab bullet
    public GameObject bulletPrefab;
    // death effect of the enemy soldier (ainda nao foi feito)
    public GameObject deathEffect;

    // Shooting Mechanics
    public Transform firePoint;
    public bool canFire = true;
    public float timestamp;

    // HEALTH BAR
    public HealthBar health;
    public int maxHealth = 100;
    public int currentHealth;

    public Player player;

    private static bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        // Set Squad member's health
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        rigidbody2D = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        health.SetHealth(currentHealth);
        // verify if the closest enemy is on the array
        if (current < enemy_npc.Length)
        {
            // verify if the current enemy is dead
            if (enemy_npc[current] == null)
            {
                current++;
            }

            else
            {

                if (canMove)
                {

                    // verify if the distance between the squad member and the enemy NPC is greater than 10
                    if (Vector3.Distance(enemy_npc[current].transform.position, transform.position) >= 10)
                    {
                        // move forward if true
                        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;


                        if (enemy_npc.Length < current)
                        {
                            current++;
                        }

                    }
                    // if it isnt, start shooting
                    else
                    {
                        // if faced left, shoot with a timestamp
                        if (canFire)
                        {
                            canFire = false;
                            // 1 second timestamp between bullets (cooldown)
                            timestamp = Time.time + 1.0f;
                            Shoot();
                        }
                        // respect the timestamp to shoot
                        else if (Time.time > timestamp)
                        {
                            canFire = true;
                        }
                    }

                }

            }
        }
    }

    // Instantiate bullets 
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // Squad member damage mechanics
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Die if health <= 0
    void Die()
    {
        //Instantiate(deathEffect, transform.position, transform.rotation);
        player.PrintMessage("One of the squad members died. Hurry up!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SMCollider"))
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float) 10.64625, (float) 12.23123);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((float) -0.6332016, (float) -0.004148483);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SMCollider"))
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float) 10.49496, (float) 22.51217);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((float) -0.6332016, (float) 5.37656);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Door")) canMove = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Door")) canMove = true;
    }

}

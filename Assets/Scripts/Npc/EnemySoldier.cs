using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class EnemySoldier : MonoBehaviour
{
    // MOVEMENT
    public float movementSpeed = 4;
    private Rigidbody2D rigidbody2D;

    // Player + friendly NPC's
    public GameObject[] squad_member;
    public GameObject player;
    int currentSquad = 0;

    // death effect of the enemy soldier (ainda nao foi feito)
    public GameObject deathEffect;

    // prefab bullet
    public GameObject bulletPrefab;

    // Shooting Mechanics
    public Transform firePoint;
    public bool canFire = true;
    public float timestamp;

    // HEALTH BAR 
    public HealthBar health;
    public int maxHealth = 100;
    public int currentHealth;

    // invisible spots where enemy soldier can move to
    public Transform[] moveSpot;
    // current moveSpot
    int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set Enemy soldier's health
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // verify the distance between the current moveSpot and the enemy soldier's position
        if (Vector3.Distance(moveSpot[current].transform.position, transform.position) < 0.2f)
        {
            current++;
            if(current >= moveSpot.Length)
            {
                current = 0;
            }

            // turn the sprite to the right
            if(current == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                health.transform.Rotate(0f, 180f, 0f);
            }

            // turn the sprite to the left
            if (current == 0)
            { 
                transform.Rotate(0f, 180f, 0f);
                health.transform.Rotate(0f, 180f, 0f);
            }
        }

        if (currentSquad < squad_member.Length)
        {
            // verify if the current enemy is dead
            if (squad_member[currentSquad] == null)
            {
                currentSquad++;
            }
            else
            {
                // verify if the distance between the soldier and the squad member/player is greater than 10
                if ((Vector3.Distance(squad_member[currentSquad].transform.position, transform.position) >= 10) && (Vector3.Distance(player.transform.position, transform.position) >= 10))
                {
                    // move forward if true
                    transform.position = Vector3.MoveTowards(transform.position, moveSpot[current].transform.position, Time.deltaTime * movementSpeed);
                }
                // if it isnt, start shooting
                else
                {
                    // if faced left, shoot with a timestamp
                    if (canFire && (player.transform.position.x < transform.position.x))
                    {
                        canFire = false;
                        // if the enemy is faced right, face left
                        if (current == 1)
                        {
                            transform.Rotate(0f, 180f, 0f);
                            health.transform.Rotate(0f, 180f, 0f);
                            current = 0;
                        }
                        // 2 seconds timestamp between bullets (cooldown)
                        timestamp = Time.time + 2.0f;
                        Shoot();
                    }

                    // if faced right, shoot with a timestamp
                    if (canFire && (player.transform.position.x > transform.position.x))
                    {
                        canFire = false;
                        // if the enemy is faced left, face right
                        if (current == 0)
                        {
                            transform.Rotate(0f, 180f, 0f);
                            health.transform.Rotate(0f, 180f, 0f);
                            current = 1;
                        }
                        // 3 seconds timestamp between bullets (cooldown)
                        timestamp = Time.time + 3.0f;
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

    // Instantiate bullets 
    void Shoot()
    {
        // shooting logic

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


    }

    // Enemy damage mechanics
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
        Destroy(gameObject);
    }
}

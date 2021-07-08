using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_enemy : MonoBehaviour
{
    // Bullet characteristics
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;



    // Start is called before the first frame update
    void Start()
    {
        // bullet's speed
        rb.velocity = transform.right * speed;
    }

    // Event when a bullet collides against another object
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Squad member object
        Squad_member squad_member = hitInfo.GetComponent<Squad_member>();
        // player object
        Player player = hitInfo.GetComponent<Player>();

        // verify if the object is not destroyed
        if (squad_member != null)
        {
            // does damage to the squad member
            squad_member.TakeDamage(damage);

            // destroy bullet after dealing damage to the squad member
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        // verify if the object is not destroyed
        if (player != null)
        {
            // does damage to the player
            player.TakeDamage(damage + 8);

            // destroy bullet after dealing damage to the player
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
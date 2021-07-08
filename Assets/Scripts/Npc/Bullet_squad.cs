using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_squad : MonoBehaviour

{
    // bullet characteristics
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
        // Enemy object
        EnemySoldier enemy = hitInfo.GetComponent<EnemySoldier>();

        // verify if the object is not destroyed
        if(enemy != null)
        {
            // does damage to the enemy soldier
            enemy.TakeDamage(damage);

            // destroy bullet after dealing damage to the soldier
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        //else {
         // if ((Vector2.Distance(squad_member.transform.position, transform.position) >= 6))
         // {
          //     Destroy(gameObject);
         // }
        //}
    }


}

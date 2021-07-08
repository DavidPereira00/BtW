using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int questNumber;
    public bool isActivated;
    public bool queststarted = false;
    public GameObject help;
    public DialogueHolder d1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (d1.talked == true)
        {
            help.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (d1.talked==false && collider.CompareTag("Player") && queststarted == false)
        {
            help.SetActive(true);

        }
    }
        void OnTriggerExit2D(Collider2D collider)
        {

            if (d1.talked==false &&collider.CompareTag("Player") && queststarted == false)
            {
                help.SetActive(false);
            }
        }
    }


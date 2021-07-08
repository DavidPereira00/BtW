using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableFloor : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            waitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            if (waitTime <= 0) {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            } else {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump")) {
            effector.rotationalOffset = 0f;
        }
    }
}

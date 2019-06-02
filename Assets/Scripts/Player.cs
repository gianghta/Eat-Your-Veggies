using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    Animator anim;
    Rigidbody2D rb;
    float input;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Set running animation when player presses keys
        if(input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //Set player facing correct direction when running
        if(input > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(input < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        //Storing player's key input
        input = Input.GetAxisRaw("Horizontal");

        //Speed of the character movement
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }
}
